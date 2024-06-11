using Domain_Layer.Domains;
using Infrastructure_Layer.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_Layer.MyContext
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext()
        {
                
        }
        public ApplicationContext(DbContextOptions options) :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicantConfigurations());
            modelBuilder.ApplyConfiguration(new UniversityConfigurations());
            modelBuilder.ApplyConfiguration(new MajorConfigurations());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Applicant> Applicants { get; set; } 
        public virtual DbSet<University> Universities { get; set; } 
        public virtual DbSet<Major> Majors { get; set; }
    }
}
