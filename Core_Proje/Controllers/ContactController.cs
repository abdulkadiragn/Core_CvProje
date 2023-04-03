using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDAL());
        public IActionResult Index()
        {
            var result = messageManager.TGetList();
            return View(result);
        }
        public IActionResult Delete(int id)
        {
            var value = messageManager.TGetById(id);
            messageManager.TDelete(value);
            return RedirectToAction("Index");
        }
        public IActionResult ContactDetails(int id)
        {
            var result = messageManager.TGetById(id);
            return View(result);
        }
    }
}
