using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical.Configuration
{
    public enum StatusID
    {
        Success = 1,
        InternalServer,
        TokenInvalid,
        IDNotFound,
        BadRequest,
        ServerBusy,
        AccessDenied,
        AlreadyExist,
        NotExisted
    }
}
