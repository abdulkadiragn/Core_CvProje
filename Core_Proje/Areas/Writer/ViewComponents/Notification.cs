using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje.Areas.Writer.ViewComponents
{
    public class Notification : ViewComponent
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDAL());
        public IViewComponentResult Invoke()
        {
            var result = announcementManager.TGetList().Take(5).ToList(); //genel bildirimlerin ilk 5'ini getir. (take'den sonra tolist her zaman koy.)
            return View(result);
        }
    }
}
