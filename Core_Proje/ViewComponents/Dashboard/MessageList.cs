using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje.ViewComponents.Dashboard
{
    public class MessageList : ViewComponent
    {
        MessageManager MessageManager = new MessageManager(new EfMessageDAL()); 
        public IViewComponentResult Invoke()
        {
            var value = MessageManager.TGetList().Take(5).ToList();
            return View(value);
        }
    }
}
