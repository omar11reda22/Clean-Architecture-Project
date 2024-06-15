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
    public class GetallUniversityHandler : IRequestHandler<GetAlluniversityQuery, List<UniversityDTO>>
    {
        private readonly IUniversityRepository universityRepository;

        public GetallUniversityHandler(IUniversityRepository universityRepository)
        {
            this.universityRepository = universityRepository;
        }

        //public Task<List<University>> Handle(GetAlluniversityQuery request, CancellationToken cancellationToken)
        //{
        //    var universites = universityRepository.getall();
        //    return Task.FromResult(universites);
        //}

         Task<List<UniversityDTO>> IRequestHandler<GetAlluniversityQuery, List<UniversityDTO>>.Handle(GetAlluniversityQuery request, CancellationToken cancellationToken)
        {
            var universities =  universityRepository.getall().Select(s => new UniversityDTO {ID = s.UNV_ID , Name = s.Name }).ToList();
            return Task.FromResult(universities);
        }
    }
}
