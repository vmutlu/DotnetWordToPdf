using RabbitMQ.Client;
using WordToPdf.Models;

namespace WordToPdf.Services.Abstract
{
    public interface IRabbitMQService
    {
        bool WordToByteSendRabbitMQ(FileTypeConversion fileTypeConversion);

        bool WordToPdfSendEmail(IModel channel, string email);
    }
}
