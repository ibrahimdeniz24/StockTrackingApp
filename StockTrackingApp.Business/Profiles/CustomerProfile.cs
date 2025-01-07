using StockTrackingApp.Dtos.Customers;

namespace StockTrackingApp.Business.Profiles
{
    public class CustomerProfile :Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Customer, CustomerCreateDto>();
            CreateMap<Customer, CustomerDetailsDto>();
            CreateMap<Customer, CustomerUpdateDto>();
        }
    }
}
