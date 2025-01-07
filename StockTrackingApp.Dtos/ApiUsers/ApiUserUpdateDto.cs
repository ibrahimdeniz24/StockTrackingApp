using Microsoft.AspNetCore.Http;


namespace StockTrackingApp.Dtos.ApiUsers
{
    public class ApiUserUpdateDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public IFormFile? NewImage { get; set; }
        public bool RemoveImage { get; set; }
    }
}
