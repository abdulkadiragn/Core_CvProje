using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje.Controllers
{
    public class UserWriterController : Controller
    {
        UserWriterManager userWriterManager = new UserWriterManager(new EfUserWriterDAL());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListUser()
        {
            var result = JsonConvert.SerializeObject(userWriterManager.TGetList()); //json ile veri cekme 
            return Json(result);
        }
        [HttpPost]
        public IActionResult AddUser(WriterUser writerUser)
        {
            userWriterManager.TAdd(writerUser);
            var result = JsonConvert.SerializeObject(writerUser);
            return Json(result);
        }
    }
}
