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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDAL testimonialDAL;

        public TestimonialManager(ITestimonialDAL testimonialDAL)
        {
            this.testimonialDAL = testimonialDAL;
        }
        public void TAdd(Testimonial t)
        {
            testimonialDAL.Insert(t);
        }

        public void TDelete(Testimonial t)
        {
            testimonialDAL.Delete(t);
        }

        public Testimonial TGetById(int id)
        {
            return testimonialDAL.GetById(id);
        }

        public List<Testimonial> TGetList()
        {
            return testimonialDAL.GetList();
        }

        public List<Testimonial> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Testimonial t)
        {
            testimonialDAL.Update(t);
        }
    }
}
