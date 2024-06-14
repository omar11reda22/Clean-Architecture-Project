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
    public class GetAllMajorsHandler : IRequestHandler<GetallMajorsQuery, List<Major>>
    {
        private readonly IMajorRepsitory majorRepsitory;

        public GetAllMajorsHandler(IMajorRepsitory majorRepsitory)
        {
            this.majorRepsitory = majorRepsitory;
        }

        public async Task<List<Major>> Handle(GetallMajorsQuery request, CancellationToken cancellationToken)
        {
            var majors = majorRepsitory.getall();
            return  Task.FromResult(majors);
        }
    }
}
