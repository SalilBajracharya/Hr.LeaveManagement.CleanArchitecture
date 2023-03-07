using Hr.LeaveManagement.Application.DTOs.LeaveAllocations;
using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveAllocations.Requests.Command
{
    public class CreateLeaveAllocationCommand : IRequest<int>
    {
        public CreateLeaveAllocationDto leaveAllocationDto { get; set; }
    }
}
