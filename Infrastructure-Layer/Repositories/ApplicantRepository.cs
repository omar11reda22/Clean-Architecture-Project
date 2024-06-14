using Domain_Layer.Domains;
using Infrastructure_Layer.MyContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_Layer.Repositories
{
    
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly ApplicationContext context;

        public ApplicantRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void add(Applicant applicant)
        {
            context.Applicants.Add(applicant);
        }

        public async Task SaveChangesAsync()
        {
           await context.SaveChangesAsync();
        }
    }
}
