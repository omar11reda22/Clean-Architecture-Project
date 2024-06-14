using Domain_Layer.Domains;
using Infrastructure_Layer.MyContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_Layer.Repositories
{
    public class MajorRepository : IMajorRepsitory
    {
        private readonly ApplicationContext context;

        public MajorRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public List<Major>? getall()
        {
            var majors =  context.Majors.AsNoTracking().OrderBy(s => s.Name).ToList();
            return majors; 
        }

       
    }
}
