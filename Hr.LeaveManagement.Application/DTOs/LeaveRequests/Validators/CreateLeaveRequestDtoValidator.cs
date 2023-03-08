using FluentValidation;
using Hr.LeaveManagement.Application.DTOs.LeaveType.Validators;
using Hr.LeaveManagement.Application.Persistence.Contracts;

namespace Hr.LeaveManagement.Application.DTOs.LeaveRequests.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            Include(new ILeaveRequestDtoValidator(_leaveTypeRepository));
        }
    }
}
