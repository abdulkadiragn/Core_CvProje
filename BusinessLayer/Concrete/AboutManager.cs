using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDAL aboutDAL;

        public AboutManager(IAboutDAL aboutDAL)
        {
            this.aboutDAL = aboutDAL;
        }

        public void TAdd(About t)
        {
            aboutDAL.Insert(t);
        }

        public void TDelete(About t)
        {
            aboutDAL.Delete(t);
        }

        public About TGetById(int id)
        {
            return aboutDAL.GetById(id);
        }

        public List<About> TGetList()
        {
            return aboutDAL.GetList();
        }

        public List<About> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(About t)
        {
            aboutDAL.Update(t);
        }
    }
}
