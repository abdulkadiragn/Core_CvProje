using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Message")] //yönlendirmelerde kolaylık saglaması için (takip etmesi için)
    public class MessageController : Controller
    {
        private readonly UserManager<WriterUser> userManager;
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDAL());

        public MessageController(UserManager<WriterUser> userManager)
        {
            this.userManager = userManager;
        }
        [Route("")]
        [Route("ReceiverMessage")]
        //aldıgımız ve gönderdigimiz mesajarı aşağıdaki 2 metod ile yakaladık.
        public async Task<IActionResult> ReceiverMessage(string a)
        {
            var result = await userManager.FindByNameAsync(User.Identity.Name);
            a = result.Email;
            var messageList = writerMessageManager.GetListReceiverMessage(a); //BLL katmanında mesaj kısmına özel olarak yazdıgımız metoda gönderdik.
            return View(messageList);
        }

        [Route("")]
        [Route("SenderMessage")]
        public async Task<IActionResult> SenderMessage(string a)
        {

            var result = await userManager.FindByNameAsync(User.Identity.Name);
            a = result.Email;
            var messageList = writerMessageManager.GetListSendMessage(a); //aynı şekilde özel metoda gönderdik.
            return View(messageList);
        }

        [Route("MessageDetails/{id}")] //dışarıdan almış oldugun id ile detaya git.
        public IActionResult MessageDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetById(id);
            return View(writerMessage);
        }

        [Route("RecieverMessageDetails/{id}")]
        public IActionResult RecieverMessageDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetById(id);
            return View(writerMessage);
        }
        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(WriterMessage writerMessage)
        {
            var result = await userManager.FindByNameAsync(User.Identity.Name); //kişi bilgileri (identity'nin güzel yanları her yerden erişebilme.)
            string mail = result.Email;
            string name = result.Name + " " + result.Lastname;
            writerMessage.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()); //günün kısa tarihini alıp atadık.
            writerMessage.Sender = mail; //gelen mail degerini parametreye atadık
            writerMessage.SenderName = name;
            Context context = new Context();

            var usernameSurname = context.Users.Where(x => x.Email == writerMessage.Receiver).Select(y => y.Name + " " + y.Lastname).FirstOrDefault(); //burayı tekrar et (db ile user bilgisini koşul ile cekerek bir degiskene atadık.)
            writerMessage.ReceiverName = usernameSurname;
            writerMessageManager.TAdd(writerMessage);
            return RedirectToAction("SenderMessage");
        }
    }
}
