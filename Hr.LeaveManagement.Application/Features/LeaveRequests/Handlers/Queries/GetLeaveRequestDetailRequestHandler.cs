using AutoMapper;
using Hr.LeaveManagement.Application.DTOs.LeaveRequests;
using Hr.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using Hr.LeaveManagement.Application.Persisitence.Contracts;
using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestDetailRequestHandler : IRequestHandler<GetLeaveRequestDetailRequest, LeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestDetailRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id);     
            return _mapper.Map<LeaveRequestDto>(leaveRequest);
        }
    }
}
