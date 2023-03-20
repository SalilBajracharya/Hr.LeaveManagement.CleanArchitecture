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

        public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType)
        {
            try
            {
                var response = new Response<int>();
                CreateLeaveTypeDto createLeaveType = _mapper.Map<CreateLeaveTypeDto>(leaveType);
                var apiResponse = await _client.LeaveTypePOSTAsync(createLeaveType);
                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else {
                    foreach (var error in apiResponse.Errors)
                    {
                        response.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return response;

            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
        public async Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
        {
            var leaveType = await _client.LeaveTypeGETAsync(id);
            return _mapper.Map<LeaveTypeVM>(leaveType);
        }
        public async Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            var leaveTypes = await _client.LeaveTypeAllAsync();
            return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);
        } 
        async Task<Response<int>> ILeaveTypeService.DeleteLeaveType(int id)
        {
            try
            {
                await _client.LeaveTypeDELETEAsync(id);
                return new Response<int>() { Success = true };
            }
            catch(ApiException ex) {
                return ConvertApiExceptions<int>(ex);
            }
        }
        async Task<Response<int>> ILeaveTypeService.UpdateLeaveType(int id, LeaveTypeVM leaveType)
        {
            try
            {
                UpdateLeaveTypeDto leaveTypeDto = _mapper.Map<UpdateLeaveTypeDto>(leaveType);
                await _client.LeaveTypePUTAsync(leaveTypeDto, CancellationToken.None);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
