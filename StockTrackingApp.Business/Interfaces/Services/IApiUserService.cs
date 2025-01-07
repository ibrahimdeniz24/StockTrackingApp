using StockTrackingApp.Dtos.ApiUsers;

namespace StockTrackingApp.Business.Interfaces.Services
{
    public interface IApiUserService
    {
        Task<IDataResult<List<ApiUserListDto>>> GetAllAsync();
        Task<IDataResult<ApiUserDto>> AddAsync(ApiUserCreateDto createApiUserDto);
        Task<IDataResult<ApiUserDto>> UpdateAsync(ApiUserUpdateDto updateApiUserDto);
        Task<IDataResult<ApiUserDto>> GetByIdAsync(Guid id);
        Task<IResult> DeleteAsync(Guid id);
    }
}
