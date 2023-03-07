using Hr.LeaveManagement.Application.DTOs.LeaveRequests;
using Hr.LeaveManagement.Domain;

namespace Hr.LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequestDto> GetLeaveRequestWithDetails(int id);
        Task<List<LeaveRequestListDto>> GetLeaveRequestsWithDetails();
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus);
    }
}
