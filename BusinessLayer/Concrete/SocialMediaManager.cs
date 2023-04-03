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
   public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDAL socialMediaDAL;

        public SocialMediaManager(ISocialMediaDAL socialMediaDAL)
        {
            this.socialMediaDAL = socialMediaDAL;
        }
        public void TAdd(SocialMedia t)
        {
            socialMediaDAL.Insert(t);
        }

        public void TDelete(SocialMedia t)
        {
            socialMediaDAL.Delete(t);
        }

        public SocialMedia TGetById(int id)
        {
            return socialMediaDAL.GetById(id);
        }

        public List<SocialMedia> TGetList()
        {
            return socialMediaDAL.GetList();
        }

        public List<SocialMedia> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(SocialMedia t)
        {
            socialMediaDAL.Update(t);
        }
    }
}
