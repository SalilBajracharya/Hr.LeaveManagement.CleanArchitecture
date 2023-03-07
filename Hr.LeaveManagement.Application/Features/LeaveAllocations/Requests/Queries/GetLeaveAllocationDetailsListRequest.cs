using Hr.LeaveManagement.Application.DTOs.LeaveAllocations;
using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationDetailsListRequest : IRequest<List<LeaveAllocationDto>>
    {
    }
}
