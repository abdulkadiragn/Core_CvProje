using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje.ViewComponents.Dashboard
{
    public class AdminNavbarMessage : ViewComponent
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDAL());
        public IViewComponentResult Invoke()
        {
            string p = "admin@gmail.com"; //bu maile atılan mesajları görüntülemek için
            var result = writerMessageManager.GetListReceiverMessage(p).OrderByDescending(x=>x.WriterMessageID).Take(3).ToList(); //orderbyDescending(z'den a'ya sırala) take ile 3 mesaj getir.
            return View(result);
        }
    }
}
