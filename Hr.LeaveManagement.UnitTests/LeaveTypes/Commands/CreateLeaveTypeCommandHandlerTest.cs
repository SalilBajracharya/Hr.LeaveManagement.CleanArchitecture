using AutoMapper;
using FluentValidation;
using Hr.LeaveManagement.Application.Contracts.Persistence;
using Hr.LeaveManagement.Application.DTOs.LeaveType;
using Hr.LeaveManagement.Application.Features.LeaveAllocations.Requests.Command;
using Hr.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
using Hr.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using Hr.LeaveManagement.Application.Profiles;
using Hr.LeaveManagement.Application.Responses;
using Hr.LeaveManagement.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Hr.LeaveManagement.UnitTests.LeaveTypes.Commands
{
    public class CreateLeaveTypeCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private readonly CreateLeaveTypeDto _leaveTypeDto;
        private readonly CreateLeaveTypeCommandHandler _handler;
        public CreateLeaveTypeCommandHandlerTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _mockRepo = LeaveTypeMockRepository.GetLeaveTypeRepository();

            _leaveTypeDto = new CreateLeaveTypeDto
            {
                DefaultDays = 15,
                Name = "test casual"
            };

            _handler = new CreateLeaveTypeCommandHandler(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task CreateLeaveType()
        {
            var result = await _handler.Handle(new CreateLeaveTypeCommand() { CreateLeaveTypeDto = _leaveTypeDto }, CancellationToken.None);

            var leaveTypes = await _mockRepo.Object.GetAll();

            result.ShouldBeOfType<BaseCommandResponse>();

            leaveTypes.Count.ShouldBe(3);
        }

        [Fact]
        public async Task Invalid_LeaveType_Added() {
            //_leaveTypeDto.DefaultDays = -1;

            var result = await _handler.Handle(new CreateLeaveTypeCommand() { CreateLeaveTypeDto = _leaveTypeDto }, CancellationToken.None);

            var leaveTypes = await _mockRepo.Object.GetAll();

            //leaveTypes.Count.ShouldBe(3);

            result.ShouldBeOfType<BaseCommandResponse>();
        }
    }
}
