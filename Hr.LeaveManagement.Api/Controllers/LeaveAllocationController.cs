using Hr.LeaveManagement.Application.DTOs.LeaveAllocations;
using Hr.LeaveManagement.Application.Features.LeaveAllocations.Requests.Command;
using Hr.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hr.LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        #region Dependency Injections
        private readonly IMediator _mediator;
        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion End of Injections

        // GET: api/<LeaveAllocation>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationDetailsListRequest());
            return Ok(leaveAllocations);
        }

        // GET api/<LeaveAllocation>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailsRequest { Id = id });
            return leaveAllocation;

        }

        // POST api/<LeaveAllocation>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationDto request)
        {
            var response = await _mediator.Send(new CreateLeaveAllocationCommand { leaveAllocationDto = request });
            return Ok(response);
        }

        // PUT api/<LeaveAllocation>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] UpdateLeaveAllocationDto request)
        {
            await _mediator.Send(new UpdateLeaveAllocationCommand { leaveAllocationDto = request });
            return NoContent();
        }

        // DELETE api/<LeaveAllocation>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveAllocationCommand { Id = id });
            return NoContent();
        }
    }
}
