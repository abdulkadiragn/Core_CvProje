using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
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
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDAL());
        public IActionResult ReceiverMessageList()
        {
            //writer kısmından admin@gmail.com diye birine mesaj atılırsa admin paneline düşmesi için
            string mail = "admin@gmail.com";
            var result = writerMessageManager.GetListReceiverMessage(mail);
            return View(result);
        }
        public IActionResult SenderMessageList()
        {
            //writer kısmından gelen mesajlara cevap verebilmek için.
            string mail = "admin@gmail.com";
            var result = writerMessageManager.GetListSendMessage(mail);
            return View(result);
        }
        public IActionResult AdminMessageDetails(int id)
        {
            var result = writerMessageManager.TGetById(id);
            return View(result);
        }
        public IActionResult AdminMessageDelete(int id)
        {
            var value = writerMessageManager.TGetById(id);
            writerMessageManager.TDelete(value);
            return RedirectToAction("SenderMessageList");
        }
        [HttpGet]
        public IActionResult AdminMessageSend()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage writerMessage)
        {
            writerMessage.Sender = "admin@gmail.com";
            writerMessage.SenderName = "Admin";
            writerMessage.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            Context context = new Context();
            var name = context.Users.Where(x => x.Email == writerMessage.Receiver).Select(y => y.Name + " " + y.Lastname).FirstOrDefault();
            writerMessage.ReceiverName = name; //alıcının adını mail adresine göre yukarıdakine göre çekip atadık.
            writerMessageManager.TAdd(writerMessage);
            return RedirectToAction("SenderMessageList");
        }
    }
}
