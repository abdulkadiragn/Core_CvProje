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
   public class PortfolioManager : IPortfolioService
    {
        private readonly IPortfolioDAL portfolioDAL;

        public PortfolioManager(IPortfolioDAL portfolioDAL)
        {
            this.portfolioDAL = portfolioDAL;
        }
        public void TAdd(Portfolio t)
        {
            portfolioDAL.Insert(t);
        }

        public void TDelete(Portfolio t)
        {
            portfolioDAL.Delete(t);
        }

        public Portfolio TGetById(int id)
        {
            return portfolioDAL.GetById(id);
        }

        public List<Portfolio> TGetList()
        {
            return portfolioDAL.GetList();
        }

        public List<Portfolio> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Portfolio t)
        {
            portfolioDAL.Update(t);
        }
    }
}
