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
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDAL());
        public IActionResult Index()
        {

            var result = serviceManager.TGetList();
            return View(result);
        }
        [HttpGet]
        public IActionResult AddService()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddService(Service  service)
        {
            serviceManager.TAdd(service);
            return RedirectToAction("Index"); 
        }
        public IActionResult DeleteService(int id)
        {
            var result = serviceManager.TGetById(id);
            serviceManager.TDelete(result);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateService(int id)
        {

            var result = serviceManager.TGetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            serviceManager.TUpdate(service);
            return RedirectToAction("Index");
        }
    }
}
