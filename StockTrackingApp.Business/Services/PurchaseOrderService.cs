using StockTrackingApp.Business.Interfaces.Services;
using StockTrackingApp.Dtos.Categories;
using StockTrackingApp.Dtos.PurchaseOrders;
using System.Linq.Expressions;

namespace StockTrackingApp.Business.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly IMapper _mapper;

        public PurchaseOrderService(IMapper mapper, IPurchaseOrderRepository purchaseOrderRepository)
        {
            _mapper = mapper;
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public async Task<IDataResult<PurchaseOrderDto>> AddAsync(PurchaseOrderCreateDto purchaseOrderCreateDto)
        {
            var purchaseOrder = _mapper.Map<PurchaseOrder>(purchaseOrderCreateDto);

            await _purchaseOrderRepository.AddAsync(purchaseOrder);
            await _purchaseOrderRepository.SaveChangesAsync();

            return new SuccessDataResult<PurchaseOrderDto>(_mapper.Map<PurchaseOrderDto>(purchaseOrder), Messages.AddSuccess);
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            try
            {
                var purchaseOrder = await _purchaseOrderRepository.GetByIdAsync(id);
                if (purchaseOrder == null)
                {
                    return new ErrorResult(Messages.DeleteFail);
                }
                await _purchaseOrderRepository.DeleteAsync(purchaseOrder);
                return new SuccessResult(Messages.DeleteSuccess);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IDataResult<List<PurchaseOrderListDto>>> GetAllAsync()
        {
            var categories = await _purchaseOrderRepository.GetAllAsync();

            return new SuccessDataResult<List<PurchaseOrderListDto>>(categories.Adapt<List<PurchaseOrderListDto>>(), Messages.ListedSuccess);
        }

        public async Task<IDataResult<PurchaseOrderDto>> GetByIdAsync(Guid id)
        {
            var purchaseOrder = await _purchaseOrderRepository.GetByIdAsync(id);
            if (purchaseOrder != null)
            {
                return new SuccessDataResult<PurchaseOrderDto>(_mapper.Map<PurchaseOrderDto>(purchaseOrder), Messages.FoundSuccess);
            }

            return new ErrorDataResult<PurchaseOrderDto>(Messages.FoundFail);
        }


        public async Task<IDataResult<PurchaseOrderDetailsDto>> GetDetailsByIdAsync(Guid id)
        {
            var purchaseOrder = await _purchaseOrderRepository.GetByIdAsync(id);
            if (purchaseOrder == null)
            {
                return new ErrorDataResult<PurchaseOrderDetailsDto>(Messages.FoundFail);
            }

            return new SuccessDataResult<PurchaseOrderDetailsDto>(_mapper.Map<PurchaseOrderDetailsDto>(purchaseOrder), Messages.FoundSuccess);
        }

        public async Task<IDataResult<PurchaseOrderDto>> UpdateAsync(PurchaseOrderUpdateDto purchaseOrderUpdateDto)
        {
            var purcaseOrder = await _purchaseOrderRepository.GetByIdAsync(purchaseOrderUpdateDto.Id);

            if (purcaseOrder ==null)
            {
                return new ErrorDataResult<PurchaseOrderDto>(Messages.FoundFail);
            }

            var updatedPurchaseOrder = _mapper.Map(purchaseOrderUpdateDto, purcaseOrder);

            await _purchaseOrderRepository.UpdateAsync(updatedPurchaseOrder);
            await _purchaseOrderRepository.SaveChangesAsync();

            return new SuccessDataResult<PurchaseOrderDto>(_mapper.Map<PurchaseOrderDto>(updatedPurchaseOrder), Messages.UpdateSuccess);
        }
    }
}
