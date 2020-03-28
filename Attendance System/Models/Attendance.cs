using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Attendance_System.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        public DateTime Attend { get; set; }

        [ForeignKey("Users")]
        public string UserID { get; set; }
        public ApplicationUser Users { get; set; }
    }
}