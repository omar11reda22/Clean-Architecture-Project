using Application_Layer.CQRS.Commands;
using Application_Layer.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Drivers_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> addnewapplicant([FromForm]ApplicantDTO applicantDTO)
        {
            if(ModelState.IsValid)
            {
                var command = new AddNewApplicantCommand(applicantDTO);
                var result = await _mediator.Send(command);
                return Ok(result);
            }else
            {
                return BadRequest("Error");
            }
           
        }
    }
}
