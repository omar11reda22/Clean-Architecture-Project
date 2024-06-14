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
    public class UniversityRepository : IUniversityRepository
    {
        private readonly ApplicationContext context;

        public UniversityRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public List<University>? getall()
        {
            var universities = context.Universities.AsNoTracking().OrderBy(s => s.Name).ToList();
            return universities;    
        }
    }
}
