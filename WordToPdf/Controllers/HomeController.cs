using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WordToPdf.Models;
using WordToPdf.Services.Abstract;

namespace WordToPdf.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRabbitMQService _rabbitMQService; 
        private readonly INotyfService _notyf;

        public HomeController(ILogger<HomeController> logger, IRabbitMQService rabbitMQService, INotyfService notyf)
        {
            _rabbitMQService = rabbitMQService;
            _logger = logger;
            _notyf = notyf;
        }

        public IActionResult WordToPdf()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WordToPdf(FileTypeConversion fileTypeConversion)
        {
            var pdfFileSendState = _rabbitMQService.WordToByteSendRabbitMQ(fileTypeConversion);

            _notyf.Information("When your word file is converted to pdf file, it will be sent to you as an email. 👀");
            
            if (pdfFileSendState)
                _notyf.Success("Your email has been sent 😂");

            else
                _notyf.Error("The application encountered an unexpected error 😢");

            return View();
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
