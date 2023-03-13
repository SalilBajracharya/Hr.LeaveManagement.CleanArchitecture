using Hr.LeaveManagement.Application.DTOs.LeaveRequests;
using Hr.LeaveManagement.Application.Features.LeaveAllocations.Requests.Command;
using Hr.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using Hr.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using Hr.LeaveManagement.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hr.LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        #region Dependency Injections
        private readonly IMediator _mediator;
        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion End

        // GET: api/<LeaveRequestController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestDto>>> Get()
        {
            var command = await _mediator.Send(new GetLeaveRequestListDetailsRequest());
            return Ok(command);
        }

        // GET api/<LeaveRequestController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> Get(int id)
        {
            var command = await _mediator.Send(new GetLeaveRequestDetailRequest { Id = id });
            return Ok(command);
        }

        // POST api/<LeaveRequestController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDto request)
        {
            var command = await _mediator.Send(new CreateLeaveRequestCommand { LeaveRequestDto = request });
            return Ok(command);
        }

        // PUT api/<LeaveRequestController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDto request)
        {
            await _mediator.Send(new UpdateLeaveRequestCommand { Id = request.Id, leaveRequestDto = request });
            return NoContent();
        }

        //PUT api/<LeaveRequestController>
        [HttpPut("changeapproval")]
        public async Task<ActionResult> ChangeApproval([FromBody] ChangeLeaveRequestApprovalDto request)
        {
            var command = new UpdateLeaveRequestCommand { Id = request.Id, ChangeLeaveRequestApprovalDto = request };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveRequestController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveRequestCommand { Id = id });
            return NoContent();
        }
    }
}
