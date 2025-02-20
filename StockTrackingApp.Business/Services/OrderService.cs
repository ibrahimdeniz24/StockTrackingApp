
using StockTrackingApp.Business.Interfaces.Services;
using StockTrackingApp.Dtos.Customers;
using StockTrackingApp.Dtos.OrderDetails;
using StockTrackingApp.Dtos.Orders;

namespace StockTrackingApp.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<OrderDto>> AddAsync(OrderCreateDto orderCreateDto)
        {
            var order = _mapper.Map<Order>(orderCreateDto);

            if (orderCreateDto.OrderDetailDtos != null && orderCreateDto.OrderDetailDtos.Any())
            {
                order.OrderDetails = orderCreateDto.OrderDetailDtos.Select(dt => _mapper.Map<OrderDetail>(dt)).ToList();
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
            var orderDto = await _orderRepository.GetByIdAsync(orderUpdateDto.Id);

            if (orderDto == null)
            {
                return new ErrorDataResult<OrderDto>(Messages.UpdateFail);
            }

            var updatedOrder = _mapper.Map(orderUpdateDto,orderDto);
            await _orderRepository.UpdateAsync(updatedOrder);
            await _orderRepository.SaveChangesAsync();

            return new SuccessDataResult<OrderDto>(_mapper.Map<OrderDto>(updatedOrder), Messages.UpdateSuccess);
        }


        
    }
}
