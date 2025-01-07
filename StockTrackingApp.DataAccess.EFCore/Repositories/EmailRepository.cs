

namespace StockTrackingApp.DataAccess.EFCore.Repositories
{
    public class EmailRepository : EFBaseRepository<Email>, IEmailRepository

    {
        public EmailRepository(StockAppDbContext context) : base(context)
        {
        }
    }
}
