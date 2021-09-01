using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical.Configuration.OutputModels
{
    public class ResponseLogin : ResponseBase
    {
        public string Token { get; set; }
        public UserInfo Info { get; set; }
    }
}
