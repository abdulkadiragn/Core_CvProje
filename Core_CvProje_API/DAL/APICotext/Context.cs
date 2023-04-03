using Core_CvProje_API.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvProje_API.DAL.APICotext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=CoreProjesiDb_2; integrated security = true;");
        }
        public DbSet<Category> Categories { get; set; }
    }
}
