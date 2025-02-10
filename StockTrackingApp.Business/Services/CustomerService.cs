
using StockTrackingApp.Business.Interfaces.Services;
using StockTrackingApp.Dtos.Categories;
using StockTrackingApp.Dtos.Customers;

namespace StockTrackingApp.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<CustomerDto>> AddAsync(CustomerCreateDto customerCreateDto)
        {
            var hasCustomer = await _customerRepository.AnyAsync(x => x.TaxNo.ToLower().Trim() == customerCreateDto.TaxNo.ToLower().Trim());
            if (hasCustomer)
            {
                return new ErrorDataResult<CustomerDto>(Messages.AddFailAlreadyExists);
            }

            var customer = _mapper.Map<Customer>(customerCreateDto);
            await _customerRepository.AddAsync(customer);
            await _customerRepository.SaveChangesAsync();

            return new SuccessDataResult<CustomerDto>(_mapper.Map<CustomerDto>(customer), Messages.AddSuccess);
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            try
            {
                var customer = await _customerRepository.GetByIdAsync(id);
                if (customer == null)
                {
                    return new ErrorResult(Messages.DeleteFail);
                }
                await _customerRepository.DeleteAsync(customer);
                await _customerRepository.SaveChangesAsync();
                return new SuccessResult(Messages.DeleteSuccess);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IDataResult<List<CustomerListDto>>> GetAllAsync()
        {
            var customers = await _customerRepository.GetAllAsync();

            return new SuccessDataResult<List<CustomerListDto>>(customers.Adapt<List<CustomerListDto>>(), Messages.ListedSuccess);

        }

        public async Task<IDataResult<CustomerDto>> GetByIdAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer != null)
            {
                return new SuccessDataResult<CustomerDto>(_mapper.Map<CustomerDto>(customer), Messages.FoundSuccess);
            }

            return new ErrorDataResult<CustomerDto>(Messages.FoundFail);
        }

        public async Task<IDataResult<CustomerDetailsDto>> GetDetailsByIdAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return new ErrorDataResult<CustomerDetailsDto>(Messages.ListNotFound);
            }

            return new SuccessDataResult<CustomerDetailsDto>(_mapper.Map<CustomerDetailsDto>(customer), Messages.ListedSuccess);
        }

        public async Task<IDataResult<CustomerDto>> UpdateAsync(CustomerUpdateDto customerUpdateDto)
        {
            var category = await _customerRepository.GetByIdAsync(customerUpdateDto.Id);
            if (category == null)
            {
                return new ErrorDataResult<CustomerDto>(Messages.FoundFail);
            }

            var updatedCustomer = _mapper.Map(customerUpdateDto, category);

            await _customerRepository.UpdateAsync(updatedCustomer);
            await _customerRepository.SaveChangesAsync();

            return new SuccessDataResult<CustomerDto>(_mapper.Map<CustomerDto>(updatedCustomer), Messages.UpdateSuccess);
        }
    }
}
