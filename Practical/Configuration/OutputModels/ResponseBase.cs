using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical.Configuration.OutputModels
{
    public class ResponseBase
    {
        public StatusID Status { get; set; }
        public string Message { get; set; }
    }
}
