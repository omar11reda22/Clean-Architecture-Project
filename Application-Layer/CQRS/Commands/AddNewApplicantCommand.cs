using Application_Layer.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.CQRS.Commands
{
    public record AddNewApplicantCommand(ApplicantDTO ApplicantDTO):IRequest<string>
    {
    }
}
