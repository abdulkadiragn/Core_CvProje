using Core_CvProje_API.DAL.APICotext;
using Core_CvProje_API.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvProje_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCategory()
        {
            using var context = new Context();
            return Ok(context.Categories.ToList());
        }

        //id ile api'den veri cekme
        [HttpGet("{id}")] //veri dönme
        public IActionResult GetById(int id)
        {
            using var context = new Context();
            var val = context.Categories.Find(id); //categories tablosundan id ile bul(find)
            if (val == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(val);
            }
        }

        //api ile veri ekleme
        [HttpPost] //veri alma
        public IActionResult CategoryAdd(Category category)
        {
            using var context = new Context();
            context.Add(category); //kaydet
            context.SaveChanges(); //database'i kaydet
            return Created("", category);
        }

        [HttpDelete] //silme
        public IActionResult CategoryDelete(int id)
        {
            using var context = new Context();
            var dvalue = context.Categories.Find(id);
            if (dvalue == null)
            {
                return NotFound();
            }
            else
            {
                context.Remove(dvalue);
                context.SaveChanges();
                return NoContent();
            }
        }
        [HttpPut] //güncelleme
        public IActionResult UpdateCategory(Category category)
        {
            using var context = new Context();
            var val = context.Find<Category>(category.CategoryID); 
            if (val==null)
            {
                return NotFound();

            }
            else
            {
                val.CategoryName = category.CategoryName;
                context.Update(val);
                context.SaveChanges();
                return NoContent();
            }
        }
    }
}
