using Application_Layer.CQRS.Queries;
using Application_Layer.DTOs;
using Domain_Layer.Domains;
using Infrastructure_Layer.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Handlers
{
    public class GetallmajorHandler : IRequestHandler<GetallMajorsQuery, List<MajorDTO>>
    {
        private readonly IMajorRepsitory majorRepsitory;

        public GetallmajorHandler(IMajorRepsitory majorRepsitory)
        {
            this.majorRepsitory = majorRepsitory;
        }
        //public async Task<List<Major>> Handle(GetallMajorsQuery request, CancellationToken cancellationToken)
        //{
        //    var majors = majorRepsitory.getall();
        //    return Task.FromResult(majors);         
        //}

        Task<List<MajorDTO>> IRequestHandler<GetallMajorsQuery, List<MajorDTO>>.Handle(GetallMajorsQuery request, CancellationToken cancellationToken)
        {
            
            var majors = majorRepsitory.getall().Select(s => new MajorDTO {ID = s.MJR_ID , Name = s.Name }).ToList();
            
            return Task.FromResult(majors);                             
        }
    }
}
