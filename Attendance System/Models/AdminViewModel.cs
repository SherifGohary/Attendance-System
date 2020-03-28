using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Attendance_System.Models
{
    public class AdminViewModel
    {
        public int Attend { get; set; }
        public string Users { get; set; }
        public int Late { get; set; }
    }
}