using Hr.LeaveManagement.Application.DTOs.LeaveRequests;
using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand : IRequest<int>
    {
        public CreateLeaveRequestDto LeaveRequestDto { get; set; }
    }
}
