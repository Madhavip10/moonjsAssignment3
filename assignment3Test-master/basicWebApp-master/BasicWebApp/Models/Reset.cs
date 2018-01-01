using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebApp.Models
{
    public class Reset
    {
        public Guid ResetId { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }
}
