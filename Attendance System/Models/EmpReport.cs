using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Attendance_System.Models
{
    public class EmpReport
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Attendance")]
        public int AttendId { get; set; }
        [ForeignKey("Users")]
        public string UserId { get; set; }
        public Attendance Attendance { get; set; }
        public ApplicationUser Users { get; set; }
    }
}