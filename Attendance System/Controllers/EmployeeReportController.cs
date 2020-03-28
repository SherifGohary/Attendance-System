using Attendance_System.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Attendance_System.Controllers
{
    public class EmployeeReportController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;


        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        // GET: EmployeeReport
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Daily()
        {

            return View();
        }

        public ActionResult Monthly()
        {
            var userID = User.Identity.GetUserId();

            var count = db.Attendance.Where(a => a.UserID == userID && a.Attend.Month == DateTime.Now.Month)
                .Select(a => a.Id).Count();

            TempData["Attendance"] = count;

            var late = db.Users.Single(a => a.Id == userID).Late;

            TempData["late"] = late;

            TempData["Absence"] = 22 - count;

            return View();
        }
    }
}