using StockTrackingApp.Dtos.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Business.Interfaces.Services
{
    public interface IAdminService
    {
        Task<IDataResult<AdminDto>> GetByIdAsync(Guid id);

        Task<IDataResult<AdminDto>> GetByIdentityIdAsync(string identityId);

        Task<IDataResult<AdminDto>> AddAsync(AdminCreateDto adminCreateDto);

        Task<IDataResult<List<AdminListDto>>> GetAllAsync();

        Task<IDataResult<AdminDto>> RoleAddAsync(AdminCreateDto adminCreateDto);
        Task<IDataResult<AdminDto>> UpdateAsync(AdminUpdateDto adminUpdateDto);

        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<AdminDetailsDto>> GetDetailsByIdAsync(Guid id);
    }
}
