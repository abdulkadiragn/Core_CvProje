using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDAL());
        public IActionResult Index()
        {

            var result = portfolioManager.TGetList();
            return View(result);
        }
        [HttpGet]
        public IActionResult AddPortfolio()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {

            //Validasyon işlemi

            PortfolioValidator validationRules = new PortfolioValidator(); //validasyon yapılam sınıfı örnekledik
            ValidationResult validationResult = validationRules.Validate(portfolio); //yukarıdan gelen portfolio ile kontrol et (Validation.result sınıfı dikkat et)
            if (validationResult.IsValid) //validasyon işlemlerinden geçerse 
            {
                portfolioManager.TAdd(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
        public IActionResult DeletePortfolio(int id)
        {
            var result = portfolioManager.TGetById(id);
            portfolioManager.TDelete(result);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdatePortfolio(int id)
        {

            var result = portfolioManager.TGetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio portfolio)
        {
            PortfolioValidator validationRules = new PortfolioValidator();
            ValidationResult validationResult = validationRules.Validate(portfolio);
            if (validationResult.IsValid)
            {
                portfolioManager.TUpdate(portfolio);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
