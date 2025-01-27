using StockTrackingApp.Dtos.Customers;

namespace StockTrackingApp.Business.Profiles
{
    public class CustomerProfile :Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<CustomerUpdateDto, Customer>();
            CreateMap<CustomerDetailsDto, Customer>();
        }
    }
}
