using Microsoft.AspNetCore.Http;



namespace StockTrackingApp.Dtos.Admins
{
    public class AdminUpdateDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IFormFile? NewImage { get; set; }
        public bool RemoveImage { get; set; }
        public Status? Status { get; set; }
    }
}
