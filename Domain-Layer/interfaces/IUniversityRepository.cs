using Domain_Layer.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_Layer.Repositories
{
    public interface IUniversityRepository
    {
        List<University>? getall(); 
    }
}
