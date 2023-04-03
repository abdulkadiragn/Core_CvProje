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
    public class ContactManager : IContactService
    {
        private readonly IContactDAL contactDAL;

        public ContactManager(IContactDAL contactDAL)
        {
            this.contactDAL = contactDAL;
        }
        public void TAdd(Contact t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Contact t)
        {
            throw new NotImplementedException();
        }

        public Contact TGetById(int id)
        {
            return contactDAL.GetById(id);
        }

        public List<Contact> TGetList()
        {
            return contactDAL.GetList();
        }

        public List<Contact> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Contact t)
        {
            contactDAL.Update(t);
        }
    }
}
