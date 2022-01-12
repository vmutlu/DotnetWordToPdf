using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Spire.Doc;
using System.IO;
using System.Text;
using WordToPdf.Models;
using WordToPdf.Services.Abstract;

namespace WordToPdf.Services
{
    public class RabbitMQService : IRabbitMQService
    {
        public bool WordToByteSendRabbitMQ(FileTypeConversion fileTypeConversion)
        {
            ConnectionFactory factory = new()
            {
                HostName = "localhost"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare("conversion-exchange", ExchangeType.Direct, true, false, null);

            //durable: true -> kuyrugu sağlama al
            channel.QueueDeclare(queue: "File", durable: true, exclusive: false, autoDelete: false, arguments: null);

            channel.QueueBind("File", "conversion-exchange", "WordToPdf");

            ResponseMessage responseMessage = new();

            using MemoryStream memoryStream = new();
            fileTypeConversion.File.CopyTo(memoryStream);
            responseMessage.WordToPdfByte = memoryStream.ToArray();
            responseMessage.Email = fileTypeConversion.Email;
            responseMessage.FileName = Path.GetFileNameWithoutExtension(fileTypeConversion.File.FileName);

            var message = JsonConvert.SerializeObject(responseMessage);
            var byteFile = Encoding.UTF8.GetBytes(message);

            //Persistent = true -> mesajı sağlama al
            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;

            channel.BasicPublish("conversion-exchange", routingKey: "WordToPdf", basicProperties: properties, body: byteFile);

            return WordToPdfSendEmail(channel, fileTypeConversion.Email);
        }

        public bool WordToPdfSendEmail(IModel channel, string email)
        {
            channel.BasicQos(0, 1, false);

            var consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume("File", false, consumer);

            consumer.Received += (model, ea) =>
            {
                Document document = new();
                string deserialize = Encoding.UTF8.GetString(ea.Body.ToArray());

                ResponseMessage file = JsonConvert.DeserializeObject<ResponseMessage>(deserialize);

                document.LoadFromStream(new MemoryStream(file.WordToPdfByte), FileFormat.Docx2013);

                using MemoryStream ms = new();
                document.SaveToStream(ms, FileFormat.PDF);

                //user information message send
                EmailSender.EmailSend(email: email, memoryStream: ms, fileName: $"You Conversion Pdf File");
            };

            return true;
        }
    }
}
