using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje.ViewComponents.About
{
    public class AboutList : ViewComponent
    {
        //featureList ile aynu işlem 
        public IViewComponentResult Invoke()
        {
            AboutManager aboutManager = new AboutManager(new EfAboutDAL());
            var result = aboutManager.TGetList();
            return View(result);
        }
    }
}
