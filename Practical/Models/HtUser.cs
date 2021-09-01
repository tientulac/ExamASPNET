using System;
using System.Collections.Generic;

#nullable disable

namespace Practical.Models
{
    public partial class HtUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string FullName { get; set; }
        public bool? Admin { get; set; }
        public bool? Active { get; set; }
        public string Email { get; set; }
    }
}
