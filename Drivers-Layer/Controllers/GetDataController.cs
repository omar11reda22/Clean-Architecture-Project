using Application_Layer.CQRS.Queries;
using Application_Layer.Handlers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Drivers_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDataController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetDataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("universities")]
        public async Task<ActionResult> GetDatauniversities()
        {
            var query = new GetAlluniversityQuery();
            var result = await _mediator.Send(query); 
            return Ok(result); 

        }
        [HttpGet("majors")]
        public async Task<ActionResult> getallmajors()
        {
            var query = new GetallMajorsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);   

        }
    }
}
