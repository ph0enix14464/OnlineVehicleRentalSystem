using OnlineVehicleRentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineVehicleRentalSystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        // GET: Admin
        OnlineVehicleDBEntities _db = new OnlineVehicleDBEntities();
        [Authorize(Roles = "Admin")]
        public ActionResult DashBoard()
        {
            return View();
        }


    }
}