using ChangeCounselling.Data.Models;
using ChangeCounselling.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChangeCounselling.Web.Controllers
{
    public class BillController : Controller
    {
        private readonly IBillData db;

        public BillController(IBillData db)
        {
            this.db = db;

        }


        // GET: Bill
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
               
        }

        // GET: Bill/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        // GET: Bill/Create
        public ActionResult Create()
        {
            var db = new SqlBookData(new CounsellorDbContext());
            var result = db.GetAll().ToList();

            ViewBag.data = result;
            return View();
        }

        // POST: Bill/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bill bill)
        {
            if (ModelState.IsValid)
            {
                db.Add(bill);
                return RedirectToAction("Details", new { id = bill.BillID });
            }
            return View();
        }

        // GET: Bill/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
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

        // POST: Bill/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Bill bill)
        {
            if (ModelState.IsValid)
            {
                db.Update(bill);
                TempData["Message"] = "You have succesfully saved the Bill!";
                return RedirectToAction("Details", new { id = bill.BillID });
            }
            return View(bill);
        }

        // GET: Bill/Delete/5
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

        // POST: Bill/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
