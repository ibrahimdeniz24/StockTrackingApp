using Microsoft.AspNetCore.Http;

namespace StockTrackingApp.Dtos.Admins
{
    public class AdminCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IFormFile? NewImage { get; set; }
        public string? IdentityId { get; set; }
    }
}
