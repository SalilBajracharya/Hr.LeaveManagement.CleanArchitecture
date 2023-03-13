using Hr.LeaveManagement.Application.Contracts.Persistence;
using Hr.LeaveManagement.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveManagement.UnitTests.Mocks
{
    public static class LeaveTypeMockRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository() {
            var leaveTypes = new List<LeaveType>
            {
                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 10,
                    Name = "Test Vacation"
                },
                new LeaveType
                {
                    Id = 2,
                    DefaultDays = 12,
                    Name = "Sick Vacation"
                }
            };

            var mockRepo = new Mock<ILeaveTypeRepository>();

            mockRepo.Setup(x => x.GetAll()).ReturnsAsync(leaveTypes);

            mockRepo.Setup(x => x.Add(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leavetype) =>
            {
                leaveTypes.Add(leavetype);
                return leavetype;
            });

            return mockRepo;
        }
    }
}
