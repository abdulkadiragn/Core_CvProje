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
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDAL());
        public IActionResult Index()
        {

            var result = skillManager.TGetList();
            return View(result);
        }
        [HttpGet]
        public IActionResult AddSkill()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            skillManager.TAdd(skill);
            return RedirectToAction("Index"); //ekleme işlemi gerçekleştikten sonra ındex'e yönlendir
        }
        public IActionResult DeleteSkill(int id)
        {
            var result = skillManager.TGetById(id);
            skillManager.TDelete(result);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {

            var result = skillManager.TGetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateSkill(Skill skill)
        {
            skillManager.TUpdate(skill);
            return RedirectToAction("Index");
        }
    }
}
