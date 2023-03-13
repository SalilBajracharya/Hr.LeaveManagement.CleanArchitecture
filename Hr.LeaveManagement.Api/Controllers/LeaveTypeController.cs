using Hr.LeaveManagement.Application.DTOs;
using Hr.LeaveManagement.Application.DTOs.LeaveType;
using Hr.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using Hr.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hr.LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveTypeController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDto>>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypeListRequest());
            return Ok(leaveTypes);
        }

        // GET api/<LeaveTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDto>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailRequest { Id = id });
            return Ok(leaveType);
        }

        // POST api/<LeaveTypeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveTypeDto request)
        {
            var command = new CreateLeaveTypeCommand { CreateLeaveTypeDto = request };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveTypeController>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateLeaveTypeDto request)
        {
            var command = new UpdateLeaveTypeCommand { LeaveTypeDto = request };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveTypeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
