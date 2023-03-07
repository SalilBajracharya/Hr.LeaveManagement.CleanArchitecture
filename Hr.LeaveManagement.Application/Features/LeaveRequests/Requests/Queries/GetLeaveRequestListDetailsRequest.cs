using Hr.LeaveManagement.Application.DTOs.LeaveRequests;
using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestListDetailsRequest : IRequest<List<LeaveRequestListDto>>
    {
    }
}
