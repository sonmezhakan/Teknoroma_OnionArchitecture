using Microsoft.AspNetCore.Mvc;
using Teknoroma.Application.Services.EmailServices;
using Teknoroma.MVC.Models;

namespace Teknoroma.MVC.Controllers
{
	public class ContactController : Controller
    {
        private readonly IMailService _mailService;

        public ContactController(IMailService mailService)
        {
           _mailService = mailService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactMailSenderViewModel model)
        {
            if(!ModelState.IsValid) return View(model);

            await _mailService.SendMailAsync("Teknoroma İletişim Sayfasından Gönderilmiştir!",
                null,
				$"<b style='color:red;'>Gönderen : </b> {model.FullName} <br/> <br/>" +
				$"<b style='color:red;'>Mail : </b> {model.Mail} <br/> <br/>" +
				$"<b style='color:red;'>Telefon Numarası : </b> {model.PhoneNumber} <br/> <br/>" +
				$"<b style='color:red;'>Konu : </b> {model.Subject} <br/> <br/>" +
				$"<b style='color:red;'>Mesaj : </b> {model.Message} <br/> <br/>",
				"teknoromaproject@outlook.com");

            return RedirectToAction("Index","Contact");
        }
    }
}
