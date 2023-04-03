using Core_CvPRoje.Areas.Writer.Models;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]

    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.Name = result.Name;
            userEditViewModel.Lastname = result.Lastname;
            userEditViewModel.PictureUrl = result.ImageUrl;
            return View(userEditViewModel);
        }

        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (userEditViewModel.Picture != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(userEditViewModel.Picture.FileName);
                var imageName = Guid.NewGuid() + extension; //alınan resim ismini benzersiz yapma.
                var savelocation = resource + "/wwwroot/UserImage/" + imageName; //hangi dosya içine kayıt yapacagı
                var stream = new FileStream(savelocation, FileMode.Create); //bu adımla beraber resim dosyası oluşturulmuş olacak
                await userEditViewModel.Picture.CopyToAsync(stream); //gelen resmi kopyalama
                user.ImageUrl = imageName; //database'de bulunan imageUrl'e alınan resmin dosya adını veriyoruz.
            }
            user.Name = userEditViewModel.Name;
            user.Lastname = userEditViewModel.Lastname;
            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, userEditViewModel.Password); //parola degistirme için.
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login"); //şifre güncellemeden sonra logine yönlendir. (route ile)
            }
            return View();
        }
    }
}
