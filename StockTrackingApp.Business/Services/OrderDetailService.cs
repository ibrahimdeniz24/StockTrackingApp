
using StockTrackingApp.Business.Interfaces.Services;
using StockTrackingApp.Dtos.Customers;
using StockTrackingApp.Dtos.OrderDetails;

namespace StockTrackingApp.Business.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<OrderDetailDto>> AddAsync(OrderDetailCreateDto orderCreateDto)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderCreateDto);

            await _orderDetailRepository.AddAsync(orderDetail);
            await _orderDetailRepository.SaveChangesAsync();

            return new SuccessDataResult<OrderDetailDto>(_mapper.Map<OrderDetailDto>(orderDetail),Messages.AddSuccess);
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            try
            {
                var orderDetail = await _orderDetailRepository.GetByIdAsync(id);
                if (orderDetail == null)
                {
                    return new ErrorResult(Messages.DeleteFail);
                }
                await _orderDetailRepository.DeleteAsync(orderDetail);
                await _orderDetailRepository.SaveChangesAsync();
                return new SuccessResult(Messages.DeleteSuccess);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IDataResult<List<OrderDetailDto>>> GetAllAsync()
        {
            var orderDetails = await _orderDetailRepository.GetAllAsync();

            return new SuccessDataResult<List<OrderDetailDto>>(orderDetails.Adapt<List<OrderDetailDto>>(), Messages.ListedSuccess);
        }

        public async Task<IDataResult<OrderDetailDto>> GetByIdAsync(Guid id)
        {
            var orderDetail = await _orderDetailRepository.GetByIdAsync(id);
            if (orderDetail != null)
            {
                return new SuccessDataResult<OrderDetailDto>(_mapper.Map<OrderDetailDto>(orderDetail), Messages.FoundSuccess);
            }

            return new ErrorDataResult<OrderDetailDto>(Messages.FoundFail);
        }

        public async Task<IDataResult<OrderDetailDetailsDto>> GetDetailsByIdAsync(Guid id)
        {
            var orderDetail = await _orderDetailRepository.GetByIdAsync(id);
            if (orderDetail != null)
            {
                return new SuccessDataResult<OrderDetailDetailsDto>(_mapper.Map<OrderDetailDetailsDto>(orderDetail), Messages.ListedSuccess);
            }

            return new ErrorDataResult<OrderDetailDetailsDto>(Messages.ListNotFound);
        }

        public async Task<IDataResult<OrderDetailDto>> UpdateAsync(OrderDetailUpdateDto orderDetailUpdateDto)
        {
            var orderDetail = await _orderDetailRepository.GetByIdAsync(orderDetailUpdateDto.Id);
            if (orderDetail == null)
            {
                return new ErrorDataResult<OrderDetailDto>(Messages.FoundFail);
            }

            var updatedCustomer = _mapper.Map(orderDetailUpdateDto, orderDetail);

            await _orderDetailRepository.UpdateAsync(updatedCustomer);
            await _orderDetailRepository.SaveChangesAsync();

            return new SuccessDataResult<OrderDetailDto>(_mapper.Map<OrderDetailDto>(updatedCustomer), Messages.UpdateSuccess);
        }
    }
}
