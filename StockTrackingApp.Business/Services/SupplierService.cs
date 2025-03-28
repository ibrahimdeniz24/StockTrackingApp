
using StockTrackingApp.Business.Interfaces.Services;
using StockTrackingApp.Dtos.Customers;
using StockTrackingApp.Dtos.Suppliers;
using System.Web.Mvc;

namespace StockTrackingApp.Business.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<SupplierDto>> AddAsync(SupplierCreateDto supplierCreateDto)
        {

            var hasSupplier = await _supplierRepository.AnyAsync(x => x.TaxNo.ToLower().Trim() == supplierCreateDto.TaxNo.ToLower().Trim());
            if (hasSupplier)
            {
                return new ErrorDataResult<SupplierDto>(Messages.AddFailAlreadyExists);
            }

            var supplier = _mapper.Map<Supplier>(supplierCreateDto);
            await _supplierRepository.AddAsync(supplier);
            await _supplierRepository.SaveChangesAsync();

            return new SuccessDataResult<SupplierDto>(_mapper.Map<SupplierDto>(supplier), Messages.AddSuccess);
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            try
            {
                var supplier = await _supplierRepository.GetByIdAsync(id);
                if (supplier == null)
                {
                    return new ErrorResult(Messages.DeleteFail);
                }
                await _supplierRepository.DeleteAsync(supplier);
                await _supplierRepository.SaveChangesAsync();
                return new SuccessResult(Messages.DeleteSuccess);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IDataResult<List<SupplierListDto>>> GetAllAsync()
        {
            var suppliers = await _supplierRepository.GetAllAsync();

            return new SuccessDataResult<List<SupplierListDto>>(suppliers.Adapt<List<SupplierListDto>>(), Messages.ListedSuccess);
        }

        public async Task<List<SelectListItem>> GetAllSupplierAsSelectListAsync()
        {
            var suppliers = await _supplierRepository.GetAllAsync();

            return suppliers.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.CompanyName
            }).ToList();
        }

        public async Task<IDataResult<SupplierDto>> GetByIdAsync(Guid id)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);
            if (supplier != null)
            {
                return new SuccessDataResult<SupplierDto>(_mapper.Map<SupplierDto>(supplier), Messages.FoundSuccess);
            }

            return new ErrorDataResult<SupplierDto>(Messages.FoundFail);
        }

        public async Task<IDataResult<SupplierDetailsDto>> GetDetailsByIdAsync(Guid id)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);
            if (supplier == null)
            {
                return new ErrorDataResult<SupplierDetailsDto>(Messages.ListNotFound);
            }

            return new SuccessDataResult<SupplierDetailsDto>(_mapper.Map<SupplierDetailsDto>(supplier), Messages.ListedSuccess);
        }

        public async Task<PagedResult<SupplierListDto>> GetPagedOrdersAsync(int pageNumber, int pageSize, string searchTerm = null)
        {
            var query = await _supplierRepository.GetAllAsync();

            var queryDto = _mapper.Map<List<SupplierListDto>>(query);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                queryDto = queryDto
                    .Where(o => o.CompanyName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            int totalCount = queryDto.Count();

            var items = queryDto
                .OrderBy(o => o.CompanyName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResult<SupplierListDto>(items, totalCount);
        }

        public async Task<IDataResult<SupplierDto>> UpdateAsync(SupplierUpdateDto supplierUpdateDto)
        {
            var supplier = await _supplierRepository.GetByIdAsync(supplierUpdateDto.Id);
            if (supplier == null)
            {
                return new ErrorDataResult<SupplierDto>(Messages.FoundFail);
            }

            var updatedSupplier = _mapper.Map(supplierUpdateDto, supplier);

            await _supplierRepository.UpdateAsync(updatedSupplier);
            await _supplierRepository.SaveChangesAsync();

            return new SuccessDataResult<SupplierDto>(_mapper.Map<SupplierDto>(updatedSupplier), Messages.UpdateSuccess);
        }
    }
}
