
using Microsoft.AspNetCore.Http;
using StockTrackingApp.Dtos.Admins;

namespace StockTrackingApp.Business.Profiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<Admin, AdminDto>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.NewImage));
            CreateMap<Admin, AdminListDto>();
            CreateMap<Admin, AdminDetailsDto>();
            CreateMap<Admin, AdminUpdateDto>();
            CreateMap<AdminUpdateDto, Admin>()
                .ForMember(dest => dest.NewImage, opt => opt.Condition(src => src.RemoveImage == true || (src.NewImage != null && src.RemoveImage == false)))
                .ForMember(dest => dest.NewImage, opt => opt.MapFrom(src => ConvertIFormFileToByteArray(src.NewImage)));
        }
        /// <summary>
        /// Verilen IFormFile dosyasını byte dizisine dönüştürür.
        /// </summary>
        /// <param name="formFile">Dönüştürülecek IFormFile dosyası.</param>
        /// <returns>Byte dizisi olarak dönüştürülmüş dosya. Eğer dosya null veya boş ise null döner.</returns>
        private byte[] ConvertIFormFileToByteArray(IFormFile formFile)
        {
            if (formFile == null || formFile.Length == 0)
                return null;

            using (var memoryStream = new MemoryStream())
            {
                formFile.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }

}
