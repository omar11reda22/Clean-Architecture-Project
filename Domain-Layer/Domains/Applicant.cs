using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Domains
{
    public class Applicant
    {
        public int ID { get; set; }
        public string? Name { get; set; } = string.Empty;
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        public string? Message { get; set; } = string.Empty;
        public string? Message2 { get; set; } = string.Empty;
        public string? Message3 { get; set; } = string.Empty;

        public string? ResumPath { get; set; } = string.Empty;
        public string? CoverPath { get; set; } = string.Empty;


        public int? yearsofexperience { get; set; }
        public int? yearsofexperience2 { get; set; }
        public int? yearsofexperience3 { get; set; }




      //  public int? academic { get; set; }

        public int? workplace { get; set; }


        // relations [foriegn keies with navitional prop]
        
        public int? UNV_ID { get; set; }
        public virtual University university { get; set; } = default!;
        public int? MJR_ID { get; set; }
        public virtual Major major { get; set; } = default!;


        // Enums
        //public enum Academic
        //{
        //    first = 1, second = 2, third = 3, fourth = 4, graduate = 5
        //}
        public enum Workplace
        {
            FullTime = 1, PartTime = 2, Hybird = 3, Remotly = 4
        }

    }


    
}
