using StockTrackingApp.Dtos.Customers;

namespace StockTrackingApp.Business.Profiles
{
    public class CustomerProfile :Profile
    {
        public CustomerProfile()
        {

            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<Customer, CustomerUpdateDto>();
            CreateMap<Customer, CustomerDetailsDto>();
            CreateMap<CustomerUpdateDto, Customer>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<Customer, CustomerListDto>();
        }
    }
}
