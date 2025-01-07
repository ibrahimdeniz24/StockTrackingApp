using StockTrackingApp.Dtos.Customers;

namespace StockTrackingApp.Business.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<IDataResult<CustomerDto>> GetByIdAsync(Guid id);
        Task<IDataResult<CustomerDto>> AddAsync(CustomerCreateDto customerCreateDto);

        Task<IDataResult<List<CustomerListDto>>> GetAllAsync();
        Task<IDataResult<CustomerDto>> UpdateAsync(CustomerUpdateDto customerUpdateDto);
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<CustomerDetailsDto>> GetDetailsByIdAsync(Guid id);
    }
}
