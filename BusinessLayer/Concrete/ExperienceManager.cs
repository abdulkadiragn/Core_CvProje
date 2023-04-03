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
    public class ExperienceManager : IExperienceService
    {
        private readonly IExperienceDAL experienceDAL;

        public ExperienceManager(IExperienceDAL experienceDAL)
        {
            this.experienceDAL = experienceDAL;
        }
        public void TAdd(Experience t)
        {
            experienceDAL.Insert(t);
        }

        public void TDelete(Experience t)
        {
            experienceDAL.Delete(t);
        }

        public Experience TGetById(int id)
        {
            return experienceDAL.GetById(id);
        }

        public List<Experience> TGetList()
        {
            return experienceDAL.GetList();
        }

        public List<Experience> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Experience t)
        {
            experienceDAL.Update(t);
        }
    }
}
