using DataAccessLayer.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core_CvPRoje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")] //yönlendirmelerde kolaylık saglaması için (takip etmesi için)

    public class DasboardController : Controller
    {
        private readonly UserManager<WriterUser> userManager;

        public DasboardController(UserManager<WriterUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = result.Name + " " + result.Lastname;

            //hava durumu APi
            string api = "117b9877d9e4e971f16020b09b7fcd61";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=ankara&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value; //apideki hangi veriyi cekmek istedigimizi söyledik.

            //istatistikler
            Context context = new Context();
            ViewBag.v1 = context.WriterMessages.Where(x=>x.Receiver==result.Email).Count(); //gelen mesaj sayısının countunu yakalıp ekrana bastık.
            ViewBag.v2 = context.Announcements.Count();
            ViewBag.v3 = context.Users.Count(); //toplam bulunan kullanıcı sayısı
            ViewBag.v4 = context.Skills.Count();
            return View();
        }
    }
}
/*http://api.openweathermap.org/data/2.5/weather?q=ankara&mode=xml&lang=tr&units=metric&appid=117b9877d9e4e971f16020b09b7fcd61*/