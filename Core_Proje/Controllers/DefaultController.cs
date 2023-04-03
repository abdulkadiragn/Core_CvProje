using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje.Controllers
{
    [AllowAnonymous] //otantike olmadan girilebilmesi için
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }
        //bir giriş olacağı için get ve post olarak yazdık post'a parametre verdik (static poli.)
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SendMessage(Message message)
        {
            MessageManager messageManager = new MessageManager(new EfMessageDAL());
            message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()); //mesajın kaydedildiği tarihi veritabanına aktarma
            message.Status = true; //gönderilen mesajın okunmamış mesaj olduğunu görmek için
            messageManager.TAdd(message);
            return PartialView();
        }
    }
}
