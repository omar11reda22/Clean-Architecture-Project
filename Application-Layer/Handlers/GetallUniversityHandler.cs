using Application_Layer.CQRS.Queries;
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
    public class GetallUniversityHandler : IRequestHandler<GetAlluniversityQuery, List<University>>
    {
        private readonly IUniversityRepository universityRepository;

        public GetallUniversityHandler(IUniversityRepository universityRepository)
        {
            this.universityRepository = universityRepository;
        }

        public Task<List<University>> Handle(GetAlluniversityQuery request, CancellationToken cancellationToken)
        {
            var universites = universityRepository.getall();
            return Task.FromResult(universites);
        }
    }
}
