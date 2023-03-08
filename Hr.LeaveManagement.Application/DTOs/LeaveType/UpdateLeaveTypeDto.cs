using Hr.LeaveManagement.Application.DTOs.Common;

namespace Hr.LeaveManagement.Application.DTOs.LeaveType
{
    public class UpdateLeaveTypeDto : BaseDto, ILeaveTypeDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
