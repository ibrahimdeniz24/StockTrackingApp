
using StockTrackingApp.Business.Interfaces.Services;
using StockTrackingApp.Dtos.PurchaseOrderDetails;

namespace StockTrackingApp.Business.Services
{
    public class PurchaseOrderDetailService : IPurchaseOrderDetailService
    {
        private readonly IPurchaseOrderDetailRepository _purchaseOrderDetailRepository;
        private readonly IMapper _mapper;

        public PurchaseOrderDetailService(IPurchaseOrderDetailRepository purchaseOrderDetailRepository, IMapper mapper)
        {
            _purchaseOrderDetailRepository = purchaseOrderDetailRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<PurchaseOrderDetailDto>> AddAsync(PurchaseOrderDetailCreateDto purchaseOrderDetailCreateDto)
        {
            var purcaseOrderDetail = _mapper.Map<PurchaseOrderDetail>(purchaseOrderDetailCreateDto);

            await _purchaseOrderDetailRepository.AddAsync(purcaseOrderDetail);
            await _purchaseOrderDetailRepository.SaveChangesAsync();

            return new SuccessDataResult<PurchaseOrderDetailDto>(_mapper.Map<PurchaseOrderDetailDto>(purcaseOrderDetail),Messages.AddSuccess);
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            try
            {
                var deletedPurchaseOrderDetail = await _purchaseOrderDetailRepository.GetByIdAsync(id);

                if (deletedPurchaseOrderDetail == null)
                {
                    return new ErrorResult(Messages.FoundFail);
                }

                await _purchaseOrderDetailRepository.DeleteAsync(deletedPurchaseOrderDetail);

                return new SuccessResult(Messages.DeleteSuccess);
            }
            catch (Exception ex)
            {

                return new ErrorResult($"Error: {ex.Message + Messages.DeleteFail}");
            }
        }

        public async Task<IDataResult<List<PurchaseOrderDetailListDto>>> GetAllAsync()
        {
            var purcaseOrderDetails = await _purchaseOrderDetailRepository.GetAllAsync();

            return new SuccessDataResult<List<PurchaseOrderDetailListDto>>(purcaseOrderDetails.Adapt<List<PurchaseOrderDetailListDto>>(), Messages.ListedSuccess);
        }

        public async Task<IDataResult<PurchaseOrderDetailDto>> GetByIdAsync(Guid id)
        {
            var purchaseOrder = await _purchaseOrderDetailRepository.GetByIdAsync(id);

            if (purchaseOrder != null)
            {
                return new SuccessDataResult<PurchaseOrderDetailDto>(_mapper.Map<PurchaseOrderDetailDto>(purchaseOrder), Messages.ListedSuccess);
            }

            return new ErrorDataResult<PurchaseOrderDetailDto>(Messages.ListNotFound);
        }

        public async Task<IDataResult<PurchaseOrderDetailDto>> UpdateAsync(PurchaseOrderDetailUpdateDto purchaseOrderDetailUpdateDto)
        {
            var purchaseOrder = await _purchaseOrderDetailRepository.GetByIdAsync(purchaseOrderDetailUpdateDto.Id);

            if (purchaseOrder == null)
            {
                return new ErrorDataResult<PurchaseOrderDetailDto>(Messages.FoundFail);
            }

            var updatedPurcaseOrderDetail = _mapper.Map(purchaseOrderDetailUpdateDto, purchaseOrder);

            await _purchaseOrderDetailRepository.UpdateAsync(updatedPurcaseOrderDetail);
            await _purchaseOrderDetailRepository.SaveChangesAsync();

            return new SuccessDataResult<PurchaseOrderDetailDto>(_mapper.Map<PurchaseOrderDetailDto>(updatedPurcaseOrderDetail), Messages.UpdateSuccess);
        }
    }
}
