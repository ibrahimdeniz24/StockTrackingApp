using StockTrackingApp.Dtos.SendMails;


namespace StockTrackingApp.Business.Interfaces.Services
{
    public interface ISendMailService
    {    /// <summary>
         /// Gönderilmeyen maili id'ye göre tekrar gönderir
         /// </summary>
         /// <param name="id">Gönderilmeyen mailin id'si</param>
         /// <returns>Gönderim başarılı olursa  SentMailDto modeli tipinde değer döner</returns>
        Task<SentMail> ResendMail(SentMail sentMail);


        /// <summary>
        /// Yeni oluşturulan admin hesabının bilgilerinin gönderilmesi için kullanırlır.
        /// </summary>
        /// <param name="email">Mailin gönderileceği mail adresi</param>
        /// <param name="url">Login sayfasının url adresi</param>
        /// <returns></returns>
        Task SendEmailNewAdmin(NewUserMailDto newUserMailDto);


        /// <summary>
        /// Giriş yapan kullanıcının iki adımlı doğrulamadaki güvenlik kodunun gönderilmesi için kullanılır.
        /// </summary>
        /// <param name="email">Mailin gönderileceği mail adresi</param>
        /// <returns>Gönderilen güvenlik kodu</returns>
        Task<int> SendEmailVerificationCode(string email);
    }
}
