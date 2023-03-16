using AutoMapper;
using Hr.LeaveManagement.MVC.Contracts;
using Hr.LeaveManagement.MVC.Models.VMs;
using Hr.LeaveManagement.MVC.Services.Base;

namespace Hr.LeaveManagement.MVC.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;

        public LeaveTypeService(ILocalStorageService localStorageService, IMapper mapper, IClient httpClient) : base(localStorageService, httpClient)
        {
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            this._httpClient = httpClient;
        }

        public Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType)
        {
            throw new NotImplementedException();
        }

        public Task DeleteLeaveType(LeaveTypeVM leaveType)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            throw new NotImplementedException();
        }

        public Task UpdateLeaveType(LeaveTypeVM leaveType)
        {
            throw new NotImplementedException();
        }
    }
}
