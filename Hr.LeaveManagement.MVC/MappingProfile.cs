﻿using AutoMapper;
using Hr.LeaveManagement.MVC.Models.VMs;
using Hr.LeaveManagement.MVC.Services.Base;

namespace Hr.LeaveManagement.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateLeaveTypeDto, CreateLeaveTypeVM>().ReverseMap();
            CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
        }
    }
}
