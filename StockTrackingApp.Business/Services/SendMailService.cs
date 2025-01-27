using StockTrackingApp.Business.Interfaces.Services;
using StockTrackingApp.Dtos.SendMails;


namespace StockTrackingApp.Business.Services
{
    public class SendMailService : ISendMailService
    {
        public Task<SentMail> ResendMail(SentMail sentMail)
        {
            throw new NotImplementedException();
        }

        public Task SendEmailNewAdmin(NewUserMailDto newUserMailDto)
        {
            throw new NotImplementedException();
        }

        public Task<int> SendEmailVerificationCode(string email)
        {
            throw new NotImplementedException();
        }
    }
}
