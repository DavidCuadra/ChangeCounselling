using ChangeCounselling.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace ChangeCounselling.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginData db;

        public LoginController(ILoginData db)
        {
            this.db = db;
        }

        //// GET: Counsellors
        //[HttpGet]
        //public ActionResult Index()
        //{
        //    var model = db.GetAll();
        //    return View(model);
        //}

        [HttpGet]
        public ActionResult Auth()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Auth(ChangeCounselling.Data.Models.Login login)
        {

            if (ModelState.IsValid)
            {
             var result= db.Auth(login);
                if (result == true)
                {           
                    return RedirectToAction("Create", "Counsellors");
                }
            }
            return View();
        }


 
    }
}