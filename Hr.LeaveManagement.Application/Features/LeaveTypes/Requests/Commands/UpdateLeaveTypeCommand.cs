using Hr.LeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateLeaveTypeCommand : IRequest<Unit>
    {
        public UpdateLeaveTypeDto LeaveTypeDto { get; set; }
    }
}
