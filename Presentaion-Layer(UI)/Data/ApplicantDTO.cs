using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentaion_Layer_UI_.Data
{
    public class ApplicantDTO
    {
        public string? Name { get; set; } = string.Empty;
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        public string? Message { get; set; } = string.Empty;
        //public string? Message2 { get; set; } = string.Empty;
        //public string? Message3 { get; set; } = string.Empty;

        public IFormFile? ResumPath { get; set; } = default!;
        public IFormFile? CoverPath { get; set; } = default!;

       // [Display(Name = "experience in .NET")]
        public int? yearsofexperience { get; set; }
      //  [Display(Name = "experience in sql server")]
        public int? yearsofexperience2 { get; set; }
      //  [Display(Name = "experience in restful API")]
        public int? yearsofexperience3 { get; set; }




        //  public int? academic { get; set; }

        public int? workplace { get; set; }


        // relations [foriegn keies with navitional prop]

        public int? UNV_ID { get; set; }

        public int? MJR_ID { get; set; }


        // Enums
        //public enum Academic
        //{
        //    first = 1, second = 2, third = 3, fourth = 4, graduate = 5
        //}
        
        

    }
}
