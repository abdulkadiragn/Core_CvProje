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
    public class ContactSubMenuController : Controller
    {
        ContactManager  contactManager = new ContactManager(new EfContactDAL());

        [HttpGet]
        public IActionResult Index()
        {

            var result = contactManager.TGetById(1); //her zaman tek id ile çalışacagı için 1 verdik.
            return View(result);
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contactManager.TUpdate(contact);
            return RedirectToAction("Index","Default");
        }
    }
}
