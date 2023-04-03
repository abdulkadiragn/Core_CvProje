using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje.ViewComponents.Dashboard
{
    public class FeatureStatistics : ViewComponent
    {
        Context context = new Context(); //tek tek managerleri çagırmak yerine database uzerinden erişmek için.
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = context.Skills.Count(); //yetenek sayısı
            ViewBag.v2 = context.Messages.Where(x => x.Status == false).Count(); //okunmamış mesaj sayısını göstersin.
           // ViewBag.v3 = context.Messages.Where(x => x.Status == true).Count(); //okunmuş mesaj sayısı.
            ViewBag.v3 = context.Experiences.Count();
            ViewBag.v4 = context.Portfolios.Count(); //proje sayısı

            return View();
        }
    }
}
