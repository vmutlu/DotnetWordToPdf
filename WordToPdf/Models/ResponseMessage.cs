namespace WordToPdf.Models
{
    public class ResponseMessage
    {
        public byte[] WordToPdfByte { get; set; }
        public string Email { get; set; }
        public string FileName { get; set; }
    }
}
