using ChangeCounselling.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChangeCounselling.Web.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index(string name)
        {
            var model = new BookingViewModel();
            model.CounsellorFirstName = name ?? "no name";
            model.Message = ConfigurationManager.AppSettings["message"];
            return View(model);
        }
    }
}