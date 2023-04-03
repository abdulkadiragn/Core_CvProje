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
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {
        FeatureManager FeatureManager = new FeatureManager(new EfFeatureDAL());

        [HttpGet]
        public IActionResult Index()
        {
            var result = FeatureManager.TGetById(1); //her zaman tek id ile çalışacagı için 1 verdik.
            return View(result);
        }

        
        [HttpPost]
        public IActionResult Index(Feature feature)
        {
            FeatureManager.TUpdate(feature);
            return RedirectToAction("Index","Default");
        }
    }
}
