using AutoMapper;
using Hr.LeaveManagement.Application.DTOs;
using Hr.LeaveManagement.Application.DTOs.LeaveAllocations;
using Hr.LeaveManagement.Application.DTOs.LeaveRequests;
using Hr.LeaveManagement.Domain;

namespace Hr.LeaveManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
        }
    }
}
