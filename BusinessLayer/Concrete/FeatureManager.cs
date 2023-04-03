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
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDAL featureDAL;

        public FeatureManager(IFeatureDAL featureDAL)
        {
            this.featureDAL = featureDAL;
        }
        public void TAdd(Feature t)
        {
            featureDAL.Insert(t);
        }

        public void TDelete(Feature t)
        {
            featureDAL.Delete(t);
        }

        public Feature TGetById(int id)
        {
            return featureDAL.GetById(id);
        }

        public List<Feature> TGetList()
        {
            return featureDAL.GetList();
        }

        public List<Feature> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Feature t)
        {
            featureDAL.Update(t);
        }
    }
}
