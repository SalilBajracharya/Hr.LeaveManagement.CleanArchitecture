﻿using Hr.LeaveManagement.Application.DTOs.Common;
using Hr.LeaveManagement.Application.DTOs.LeaveType;

namespace Hr.LeaveManagement.Application.DTOs
{
    public class LeaveTypeDto : BaseDto, ILeaveTypeDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
