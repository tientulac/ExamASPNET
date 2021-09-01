using Practical.Configuration.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical.Configuration.OutputModels
{
    public class ResponseStudent : ResponseBase
    {
        public List<RequestStudent> Data { get; set; }
    }
}
