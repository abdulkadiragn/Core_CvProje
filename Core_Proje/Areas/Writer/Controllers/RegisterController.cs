using Core_CvPRoje.Areas.Writer.Models;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class RegisterController : Controller
    {
        private readonly UserManager<WriterUser> userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            this.userManager = userManager;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel userRegisterViewModel)
        {

            WriterUser writerUser = new WriterUser()
            {
                Name = userRegisterViewModel.Name,
                Lastname = userRegisterViewModel.Lastname,
                Email = userRegisterViewModel.Mail,
                UserName = userRegisterViewModel.UserName,
                ImageUrl = userRegisterViewModel.ImageUrl,

            };
            if (userRegisterViewModel.Password == userRegisterViewModel.ConfirmPassword)
            {
                var result = await userManager.CreateAsync(writerUser, userRegisterViewModel.Password);  

            if (result.Succeeded) //yukarıdaki kayıt işlemleri başarılı olursa
            {
                return RedirectToAction("Index", "Login");
            }
            else //result hata verirse hataları foreach ile dönüyoruz.
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            }

            return View(userRegisterViewModel);
        }
    }
}
// 123456Aa_ şifre