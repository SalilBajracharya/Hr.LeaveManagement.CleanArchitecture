using Hr.LeaveManagement.Application.DTOs.LeaveRequests;
using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestDetailRequest : IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}
