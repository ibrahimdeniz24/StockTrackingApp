
using Microsoft.EntityFrameworkCore;
using StockTrackingApp.Business.Interfaces.Services;
using StockTrackingApp.Core.Utilities.Helpers;
using StockTrackingApp.Dtos.Customers;
using StockTrackingApp.Dtos.OrderDetails;
using StockTrackingApp.Dtos.Orders;

namespace StockTrackingApp.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, ICustomerRepository customerRepository, IStockRepository stockRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _stockRepository = stockRepository;
        }

        public async Task<IDataResult<OrderDto>> AddAsync(OrderCreateDto orderCreateDto)
        {
            var order = _mapper.Map<Order>(orderCreateDto);

            order.OrderNo = GenerateOrderNo();

            if (orderCreateDto.OrderDetailDtos != null && orderCreateDto.OrderDetailDtos.Any())
            {
                order.OrderDetails = orderCreateDto.OrderDetailDtos.Select(dt => _mapper.Map<OrderDetail>(dt)).ToList();
            }

            // Stok güncellemelerini ve kontrolünü başlat
            foreach (var orderDetail in order.OrderDetails)
            {
                var stock = await _stockRepository.GetByIdAsync(orderDetail.StockId);

                // Ürün bulunamazsa veya yeterli stok yoksa hata döndür
                if (stock == null)
                {
                    return new ErrorDataResult<OrderDto>("Ürün bulunamadı.");
                }

                if (stock.Quantity < orderDetail.Quantity)
                {
                    return new ErrorDataResult<OrderDto>($"Ürün {stock.Product.Name} için yeterli stok bulunmuyor.");
                }

                // Yeterli stok varsa, stok miktarını güncelle
                stock.Quantity -= orderDetail.Quantity;
                await _stockRepository.UpdateAsync(stock);
                await _stockRepository.SaveChangesAsync();
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

            var updatedOrder = _mapper.Map(orderUpdateDto, order);
            await _orderRepository.UpdateAsync(updatedOrder);
            await _orderRepository.SaveChangesAsync();

            return new SuccessDataResult<OrderDto>(_mapper.Map<OrderDto>(updatedOrder), Messages.UpdateSuccess);
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


    }
}
