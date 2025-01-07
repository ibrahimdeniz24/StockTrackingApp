
using StockTrackingApp.Dtos.Emails;
using System.Linq.Expressions;

namespace StockTrackingApp.Business.Interfaces.Services
{
    public interface IEmailService
    {
        Task<bool> AnyAsync(Expression<Func<Email, bool>> expression);
        Task<IDataResult<List<EmailDto>>> GetAllByIdentityIdAsync(string identityId);
        Task<IDataResult<List<string>>> GetEmailAddressesByIdentityIdAsync(string identityId);
        Task<IDataResult<EmailDto>> AddAsync(EmailCreateDto emailCreateDto);
        Task<IDataResult<List<EmailDto>>> AddRangeAsync(List<EmailCreateDto> emailsCreateDto);
        Task<IDataResult<EmailDto>> UpdateAsync(EmailUpdateDto emailUpdateDto);
        Task<IDataResult<List<EmailDto>>> UpdateRangeAsync(List<EmailCreateDto> emailsCreateDto, string identityId);
        Task<IResult> DeleteAsync(Guid id);
        Task<IResult> DeleteRangeAsync(List<Guid> ids);
    }
}
