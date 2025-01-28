using StockTrackingApp.Dtos.ApiUsers;

namespace StockTrackingApp.Business.Interfaces.Services
{
    public interface IApiUserService
    {
        /// <summary>
        /// Tüm API kullanıcılarını asenkron olarak getirir.
        /// </summary>
        /// <returns>API kullanıcısı DTO'larından oluşan bir listeyi içeren veri sonucu.</returns>
        Task<IDataResult<List<ApiUserListDto>>> GetAllAsync();

        /// <summary>
        /// Yeni bir api kullanıcısını asenkron olarak ekler.
        /// </summary>
        /// <param name="createApiUserDto">Oluşturulacak kullanıcının bilgilerini içeren DTO.</param>
        /// <returns>Oluşturulan API kullanıcısı DTO'sunu içeren veri sonucu.</returns>
        Task<IDataResult<ApiUserDto>> AddAsync(ApiUserCreateDto createApiUserDto);

        /// <summary>
        /// Bir API kullanıcısını asenkron olarak günceller.
        /// </summary>
        /// <param name="updateApiUserDto">Kullanıcının güncellenmiş bilgilerini içeren DTO.</param>
        /// <returns>Güncellenmiş API kullanıcısı DTO'sunu içeren veri sonucu.</returns>
        Task<IDataResult<ApiUserDto>> UpdateAsync(ApiUserUpdateDto updateApiUserDto);

        /// <summary>
        /// ID'ye göre bir API kullanıcısını asenkron olarak getirir.
        /// </summary>
        /// <param name="id">Getirilecek kullanıcının ID'si.</param>
        /// <returns>API kullanıcısı DTO'sunu içeren veri sonucu.</returns>
        Task<IDataResult<ApiUserDto>> GetByIdAsync(Guid id);

        /// <summary>
        /// API kullanıcısını asenkron olarak siler.
        /// </summary>
        /// <param name="id">Silinecek kullanıcının ID'si.</param>
        /// <returns>Silme işleminin başarı veya başarısızlığını belirten sonuç.</returns>
        Task<IResult> DeleteAsync(Guid id);
    }
}
