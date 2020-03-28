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
    public class AttendanceController : Controller
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

        // GET: Attendance
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(Attendance model)
        {
            var user = await UserManager.FindByNameAsync(model.Users.UserName);
            var userId = user.Id;
            var date = DateTime.Now;

            TempData["UserName"] = user.UserName;
            TempData["Attend"] = date.ToString("HH:mm:ss tt");
            
            Attendance att = new Attendance() { UserID = userId, Attend = date };

            if (date.Hour > 9)
            {
                var res = db.Users.Single(a => a.Id == userId);
                res.Late++;
            }

            db.Attendance.Add(att);
            db.SaveChanges();
            return View("TimeAttend");
        }

        public ActionResult TimeAttend()
        {
            return View();
        }
    }
}