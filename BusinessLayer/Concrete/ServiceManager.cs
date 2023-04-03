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
    public class ServiceManager : IServiceService
    {
        private readonly IServiceDAL serviceDAL;

        public ServiceManager(IServiceDAL serviceDAL)
        {
            this.serviceDAL = serviceDAL;
        }
        public void TAdd(Service t)
        {
            serviceDAL.Insert(t);
        }

        public void TDelete(Service t)
        {
            serviceDAL.Delete(t);
        }

        public Service TGetById(int id)
        {

            return serviceDAL.GetById(id);
        }

        public List<Service> TGetList()
        {
           return serviceDAL.GetList();
        }

        public List<Service> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Service t)
        {

            serviceDAL.Update(t);
        }
    }
}
