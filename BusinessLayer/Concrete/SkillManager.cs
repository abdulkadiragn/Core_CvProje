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
    public class SkillManager : ISkillService
    {
        private readonly ISkillDAL skillDAL;

        public SkillManager(ISkillDAL skillDAL)
        {
            this.skillDAL = skillDAL;
        }
        public void TAdd(Skill t)
        {
            skillDAL.Insert(t);
        }

        public void TDelete(Skill t)
        {
            skillDAL.Delete(t);
        }

        public Skill TGetById(int id)
        {
            return skillDAL.GetById(id);
        }

        public List<Skill> TGetList()
        {
            return skillDAL.GetList();
        }

        public List<Skill> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Skill t)
        {
            skillDAL.Update(t);
        }
    }
}
