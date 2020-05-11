using ChangeCounselling.Data.Models;
using ChangeCounselling.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ChangeCounselling.Web.Controllers
{
    public class CounsellorsController : Controller
    {
        private readonly ICounsellorData db;

        public CounsellorsController(ICounsellorData db)
        {
            this.db = db;
        }

        // GET: Counsellors
        [HttpGet]
        public ActionResult Index()
        {

           var model = db.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        public ActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Counsellor counsellor)
        {

            if (ModelState.IsValid)
            {
                db.Add(counsellor);
                return RedirectToAction("Details", new { id = counsellor.CounsellorID });
            }
            return View();
        }

        [HttpGet]
      
        public ActionResult Edit(int id)
        {

            var model = db.Get(id);
            if(model == null)
            {
                {
                    return HttpNotFound();
                }
            }
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Counsellor counsellor)
        {



            if (ModelState.IsValid)
            {
                db.Update(counsellor);
                TempData["Message"] = "You have succesfully saved the Counsellor!";
                return RedirectToAction("Details", new { id = counsellor.CounsellorID });
            }
            return View(counsellor);



        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                {
                    return HttpNotFound();
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}