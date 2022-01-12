using System.IO;
using System.Net.Mail;
using System.Net.Mime;

namespace WordToPdf.Services
{
    public static class PdfCreator
    {
        public static Attachment PdfCreate(MemoryStream memoryStream, string fileName)
        {
            memoryStream.Position = 0;

            ContentType contentType = new(MediaTypeNames.Application.Pdf);

            Attachment attachment = new(memoryStream, contentType);
            attachment.ContentDisposition.FileName = $"{fileName}.pdf";

            return attachment;
        }
    }
}
