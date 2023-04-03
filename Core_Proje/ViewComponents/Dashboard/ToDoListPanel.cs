using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje.ViewComponents.Dashboard
{
    public class ToDoListPanel : ViewComponent
    {
        ToDoListManager  ToDoList = new ToDoListManager(new EfToDoListDAL());
        public IViewComponentResult Invoke()
        {
            var result = ToDoList.TGetList();
            return View(result);
        }
    }
}
