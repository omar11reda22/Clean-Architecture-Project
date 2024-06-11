using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Domains
{
    public class Major
    {
        public int MJR_ID { get; set; }
        public string Name { get; set; } = string.Empty; 

        public virtual ICollection<Applicant> Applicants { get; set; }
    }
}
