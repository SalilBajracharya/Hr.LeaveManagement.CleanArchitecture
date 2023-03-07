using AutoMapper;
using Hr.LeaveManagement.Application.DTOs.LeaveRequests;
using Hr.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using Hr.LeaveManagement.Application.Persisitence.Contracts;
using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestListDetailsRequestHandler : IRequestHandler<GetLeaveRequestListDetailsRequest, List<LeaveRequestListDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestListDetailsRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestListDetailsRequest request, CancellationToken cancellationToken)
        {
            var leaveRequests = await _leaveRequestRepository.GetLeaveRequestsWithDetails();
            return _mapper.Map<List<LeaveRequestListDto>>(leaveRequests);
        }
    }
}
