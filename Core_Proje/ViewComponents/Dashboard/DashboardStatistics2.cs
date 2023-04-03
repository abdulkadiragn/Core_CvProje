using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje.ViewComponents.Dashboard
{
    public class DashboardStatistics2 : ViewComponent
    {
        Context context = new Context(); 
        public IViewComponentResult Invoke() 
        {
            //dashboard ana sayfada istatistiklere sayı dönmek icin.
            ViewBag.a1 = context.Portfolios.Count();
            ViewBag.a2 = context.Messages.Where(x => x.Status == false).Count();
            ViewBag.a3 = context.Services.Count();
            return View();
        }
    }
}
