using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical.Configuration.InputModels
{
    public class RequestStudent
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber {get;set;}
        public string Email { get; set; }
    }
}
