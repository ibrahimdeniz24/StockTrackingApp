
using StockTrackingApp.Business.Interfaces.Services;
using StockTrackingApp.Core.Enums;
using StockTrackingApp.Dtos.Orders;
using StockTrackingApp.Entities.Enums;

namespace StockTrackingApp.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, ICustomerRepository customerRepository, IStockRepository stockRepository, IOrderDetailRepository orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _stockRepository = stockRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<IDataResult<OrderDto>> AddAsync(OrderCreateDto orderCreateDto)
        {
            var order = _mapper.Map<Order>(orderCreateDto);

            order.OrderNo = GenerateOrderNo();

            if (orderCreateDto.OrderDetailDtos != null && orderCreateDto.OrderDetailDtos.Any())
            {
                order.OrderDetails = orderCreateDto.OrderDetailDtos.Select(dt => _mapper.Map<OrderDetail>(dt)).ToList();
            }

            // Stok kontrolünü başlat
            foreach (var orderDetail in order.OrderDetails)
            {
                var stock = await _stockRepository.GetByIdAsync(orderDetail.StockId);

                // Ürün bulunamazsa hata döndür
                if (stock == null)
                {
                    return new ErrorDataResult<OrderDto>("Ürün bulunamadı.");
                }

                // Stok yeterli mi kontrol et
                if (stock.Quantity < orderDetail.Quantity)
                {
                    return new ErrorDataResult<OrderDto>($"Ürün {stock.Product.Name} için yeterli stok bulunmuyor.");
                }
            }

            // Sipariş 'Approved' durumundaysa stok güncellemesini yap
            if (order.OrderStatus == OrderStatus.Approved)
            {
                await UpdateStockForApprovedOrder(order);
            }

            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync();

            var orderDto = _mapper.Map<OrderDto>(order);
            return new SuccessDataResult<OrderDto>(_mapper.Map<OrderDto>(orderDto), Messages.AddSuccess);
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            try
            {
                var order = await _orderRepository.GetByIdAsync(id);
                if (order == null)
                {
                    return new ErrorResult(Messages.DeleteFail);
                }
                await _orderRepository.DeleteAsync(order);
                await _orderRepository.SaveChangesAsync();
                return new SuccessResult(Messages.DeleteSuccess);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IDataResult<List<OrderListDto>>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();

            return new SuccessDataResult<List<OrderListDto>>(orders.Adapt<List<OrderListDto>>(), Messages.ListedSuccess);
        }


        public async Task<IDataResult<OrderDto>> GetByIdAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order != null)
            {
                return new SuccessDataResult<OrderDto>(_mapper.Map<OrderDto>(order), Messages.FoundSuccess);
            }

            return new ErrorDataResult<OrderDto>(Messages.FoundFail);
        }

        public async Task<IDataResult<OrderDetailsDto>> GetDetailsByIdAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return new ErrorDataResult<OrderDetailsDto>(Messages.ListNotFound);
            }

            return new SuccessDataResult<OrderDetailsDto>(_mapper.Map<OrderDetailsDto>(order), Messages.ListedSuccess);
        }

        public async Task<IDataResult<OrderDto>> UpdateAsync(OrderUpdateDto orderUpdateDto)
        {
            var order = await _orderRepository.GetByIdAsync(orderUpdateDto.Id);

            if (order == null)
            {
                return new ErrorDataResult<OrderDto>(Messages.UpdateFail);
            }

            var oldOrderDetails = order.OrderDetails.ToList();

            if (order.OrderStatus == OrderStatus.Approved)
            {
                await RestoreStockForPreviousOrder(oldOrderDetails);
            }

            _mapper.Map(orderUpdateDto, order);

            if (orderUpdateDto.OrderDetailDtos != null && orderUpdateDto.OrderDetailDtos.Any())
            {
                await _orderDetailRepository.DeleteRangeAsync(order.OrderDetails); // await eklendi ✅

                order.OrderDetails = orderUpdateDto.OrderDetailDtos
                    .Select(dto =>
                    {
                        var detail = _mapper.Map<OrderDetail>(dto);
                        detail.OrderId = order.Id;
                        return detail;
                    }).ToList();
            }

            foreach (var detail in order.OrderDetails)
            {
                var stock = await _stockRepository.GetByIdAsync(detail.StockId);

                if (stock == null)
                {
                    return new ErrorDataResult<OrderDto>("Ürün bulunamadı.");
                }

                if (stock.Quantity < detail.Quantity)
                {
                    var productName = stock.Product?.Name ?? "Bilinmeyen Ürün";
                    return new ErrorDataResult<OrderDto>($"Ürün '{productName}' için yeterli stok yok.");
                }
            }

            if (order.OrderStatus == OrderStatus.Approved)
            {
                await UpdateStockForApprovedOrder(order);
            }

            await _orderRepository.UpdateAsync(order);
            await _orderRepository.SaveChangesAsync();

            return new SuccessDataResult<OrderDto>(_mapper.Map<OrderDto>(order), Messages.UpdateSuccess);
        }








        public string GenerateOrderNo()
        {
            return $"ORD-{DateTime.UtcNow:yyyyMMdd}-{new Random().Next(100000, 999999)}";
        }

        public async Task<PagedResult<OrderListDto>> GetPagedOrdersAsync(int pageNumber, int pageSize, string searchTerm = null)
        {
            // Asenkron veriyi alıyoruz ve sorguyu IQueryable üzerinde işleyeceğiz
            var query = await _orderRepository.GetAllAsync();


            // Query'yi OrderDto'ya dönüştürüyoruz (Mapster ya da AutoMapper kullanılıyor)
            var queryDto = _mapper.Map<List<OrderListDto>>(query);

            // Eğer arama terimi varsa, müşteri adında arama yapıyoruz
            if (!string.IsNullOrEmpty(searchTerm))
            {
                queryDto = queryDto
                      .Where(o => o.CustomerName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                      .ToList();
            }
            // Sayfa başına veriyi alıyoruz
            var totalCount = queryDto.Count(); // Toplam kayıt sayısını alıyoruz

            // Sayfalama işlemi
            var items = queryDto
                .OrderBy(o => o.OrderDate) // Sıralama işlemi
                .Skip((pageNumber - 1) * pageSize) // Sayfayı atla
                .Take(pageSize) // Sayfa başına verileri al
                .ToList(); // Listeye çevir

            return new PagedResult<OrderListDto>(items, totalCount);
        }
        private async Task UpdateStockForApprovedOrder(Order order)
        {
            foreach (var orderDetail in order.OrderDetails)
            {
                var stock = await _stockRepository.GetByIdAsync(orderDetail.StockId);
                if (stock == null) continue;

                stock.Quantity -= orderDetail.Quantity;

                await _stockRepository.UpdateAsync(stock); // sadece güncellemeyi işaretle
            }

            //await _stockRepository.SaveChangesAsync(); // tüm değişiklikleri kaydet
        }


        private async Task RestoreStockForPreviousOrder(List<OrderDetail> oldOrderDetails)
        {
            foreach (var oldDetail in oldOrderDetails)
            {
                var stock = await _stockRepository.GetByIdAsync(oldDetail.StockId);
                if (stock == null) continue;

                stock.Quantity += oldDetail.Quantity;
                await _stockRepository.UpdateAsync(stock); // içinde SaveChanges varsa burada bırak
            }

            //await _stockRepository.SaveChangesAsync(); // tüm değişiklikleri kaydet
        }


        public async Task<IResult> ChangeStatusAsync(Guid orderId, OrderStatus newStatus)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                return new ErrorResult(Messages.UpdateFail);
            }

            order.OrderStatus = newStatus;
            await _orderRepository.UpdateAsync(order);
            await _orderRepository.SaveChangesAsync();

            return new SuccessResult(Messages.UpdateSuccess);
        }
    }
}
