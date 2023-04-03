using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje.ViewComponents.SocialMedia
{
    public class SocialMediaList : ViewComponent
    {
        SocialMediaManager SocialMedia = new SocialMediaManager(new EfSocialMediaDAL());
        public IViewComponentResult Invoke()
        {
            var result = SocialMedia.TGetList();
            return View(result);
        }
    }
}
