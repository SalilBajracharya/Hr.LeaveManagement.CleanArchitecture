using AutoMapper;
using Hr.LeaveManagement.Application.DTOs;
using Hr.LeaveManagement.Application.Features.LeaveAllocation.Requests.Queries;
using Hr.LeaveManagement.Application.Persisitence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveManagement.Application.Features.LeaveAllocation.Handlers.Queries
{
    public class GetLeaveAllocationDetailsListRequestHandler : IRequestHandler<GetLeaveAllocationDetailsListRequest, List<LeaveAllocationDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationDetailsListRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationDetailsListRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocations = await _leaveAllocationRepository.GetLeaveAllocationsWithDetail();
            return _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);
        }
    }
}
