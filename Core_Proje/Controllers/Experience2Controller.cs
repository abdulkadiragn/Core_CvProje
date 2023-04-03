using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje.Controllers
{
    [Authorize(Roles = "Admin")]
    //bu controller ajax ile deneyim listeleme, ekleme vb. işlemler için
    public class Experience2Controller : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDAL());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListExperience()
        {
            var result = JsonConvert.SerializeObject(experienceManager.TGetList()); //json ile veri cekme 
            return Json(result);
        }
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.TAdd(experience);
            var result = JsonConvert.SerializeObject(experience);
            return Json(result);
        }
        public IActionResult GetById(int ExprerienceID)
        {
            var x = experienceManager.TGetById(ExprerienceID);
            var values = JsonConvert.SerializeObject(x);
            return Json(values);
        }
        public IActionResult DeleteExperience(int id)
        {
            var x = experienceManager.TGetById(id);
            experienceManager.TDelete(x);
            return NoContent();
        }
    }
}
