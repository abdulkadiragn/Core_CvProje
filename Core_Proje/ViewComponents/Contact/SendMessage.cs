using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje.ViewComponents.Contact
{
    public class SendMessage : ViewComponent
    {
        //bir giriş olacağı için get ve post olarak yazdık post'a parametre verdik (static poli.)
        MessageManager messageManager = new MessageManager(new EfMessageDAL());

        [HttpGet]
        public IViewComponentResult Invoke()
        {
            return View();
        }
        
        //[HttpPost]
        //public IViewComponentResult Invoke(Message message)
        //{
        //    message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()); //mesajın kaydedildiği tarihi veritabanına aktarma
        //    message.Status = true; //gönderilen mesajın okunmamış mesaj olduğunu görmek için
        //    messageManager.TAdd(message);
        //    return View();
        //}
    }
}
