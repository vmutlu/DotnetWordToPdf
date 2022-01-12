using Microsoft.AspNetCore.Http;

namespace WordToPdf.Models
{
    public class FileTypeConversion
    {
        public string Email { get; set; }
        public IFormFile File { get; set; }
    }
}
