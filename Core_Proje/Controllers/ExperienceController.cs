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
    [Authorize(Roles = "Admin")] //sadece admin girebilmesi için
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDAL());
        public IActionResult Index()
        {

            var result = experienceManager.TGetList();
            return View(result);
        }
        [HttpGet]
        public IActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.TAdd(experience);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteExperience(int id)
        {
            var result = experienceManager.TGetById(id);
            experienceManager.TDelete(result);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {

            var result = experienceManager.TGetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            experienceManager.TUpdate(experience);
            return RedirectToAction("Index");
        }
    }
}
