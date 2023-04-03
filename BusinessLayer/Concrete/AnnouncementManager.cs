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
    public class AnnouncementManager : IAnnouncementService
    {
        private readonly IAnnouncementDAL announcementDAL;

        public AnnouncementManager(IAnnouncementDAL announcementDAL)
        {
            this.announcementDAL = announcementDAL;
        }
        public void TAdd(Announcement t)
        {
            announcementDAL.Insert(t);
        }

        public void TDelete(Announcement t)
        {
            announcementDAL.Delete(t);
        }

        public Announcement TGetById(int id)
        {
            return announcementDAL.GetById(id);
        }

        public List<Announcement> TGetList()
        {
            return announcementDAL.GetList();
        }

        public List<Announcement> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Announcement t)
        {
            announcementDAL.Update(t);
        }
    }
}
