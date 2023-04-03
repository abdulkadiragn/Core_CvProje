using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje.ViewComponents.Feature
{
    //ViewComponents'i biz oluşturduk (Yazarken algılaması için dikkat et.) class'ı ViewComponent den kalıttık (AspNetCore.Mvc)
    //ViewComponentleri .net default olarak shared içinde aradığı için Shared içine Components dosyası açtık içerisine class ile aynı dosya açtık
    public class FeatureList : ViewComponent
    {
        //yetenekleri db'den çekip getirecegiz.
        FeatureManager featureManager = new FeatureManager(new EfFeatureDAL());
        public IViewComponentResult Invoke()
        {
            var result = featureManager.TGetList();
            return View(result); //geriye dönecek degeri unutma (unuttuğun için 2 saat hata aradın)
        }
    }
}
