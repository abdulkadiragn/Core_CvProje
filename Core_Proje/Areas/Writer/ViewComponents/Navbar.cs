using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje.Areas.Writer.ViewComponents
{
    public class Navbar : ViewComponent
    {
        private readonly UserManager<WriterUser> userManager;

        public Navbar(UserManager<WriterUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = result.ImageUrl;
            return View();
        }
    }
}
