using System.Text;

namespace StockTrackingApp.UI.Extantions
{
    public static class FormFileExtantions
    {
        public static async Task<string> FileToStringAsync(this IFormFile formFile)
        {
            using MemoryStream memoryStream = new();
            await formFile.CopyToAsync(memoryStream);
            return Convert.ToBase64String(memoryStream.ToArray());
        }

        public static async Task<byte[]> FileToByteArrayAsync(this IFormFile formFile)
        {
            if (formFile == null || formFile.Length == 0)
            {
                throw new ArgumentException("Dosya yüklenmedi veya boş.", nameof(formFile));
            }

            using MemoryStream memoryStream = new();
            await formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }

        public static async Task<string> DocumentFileToStringAsync(this IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                byte[] bytes = memoryStream.ToArray();
                return Encoding.UTF8.GetString(bytes);
            }
        }
    }
}
