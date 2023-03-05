﻿using Hr.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveManagement.Application.Persisitence.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {

    }
}
