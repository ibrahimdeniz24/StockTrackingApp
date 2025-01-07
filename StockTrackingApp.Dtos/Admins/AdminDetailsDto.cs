

namespace StockTrackingApp.Dtos.Admins
{
    public class AdminDetailsDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[]? NewImage { get; set; }
        public string? IdentityId { get; set; }
    }
}
