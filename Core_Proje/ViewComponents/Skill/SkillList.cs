using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje.ViewComponents.Skill
{
    public class SkillList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            SkillManager skillManager = new SkillManager(new EfSkillDAL());
            var result = skillManager.TGetList();
            return View(result);
        }
    }
}
