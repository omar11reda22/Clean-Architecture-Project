using Application_Layer.DTOs;
using Domain_Layer.Domains;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.CQRS.Queries
{
    public record GetAlluniversityQuery :IRequest<List<UniversityDTO>>
    {
    }
}
