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
        private readonly IBookData dbBook;
        private readonly IClientData dbClient;
        private readonly ICounsellorData dbCounsellor;

        public BillController(IBillData db, IClientData dbClient, ICounsellorData dbCounsellor,IBookData dbBook)
        {
            this.db = db;
            this.dbClient = dbClient;
            this.dbCounsellor = dbCounsellor;
            this.dbBook = dbBook;
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
            var dbBook = new SqlBookData(new CounsellorDbContext());
            var result = dbBook.GetAll().ToList();

            ViewBag.data = result;

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

            var book = this.dbBook.Get(bill.BookID);



            bill.DateTime = DateTime.Now;
            bill.ClientFirstName = dbClient.Get(book.ClientID).ClientFirstName;
            bill.ClientLastName = dbClient.Get(book.ClientID).ClientLastName;
            bill.ClientEmail = dbClient.Get(book.ClientID).ClientEmail;
            bill.CounsellorFirstName = dbCounsellor.Get(book.CounsellorID).CouncellorFirstName;
            bill.CounsellorLastName = dbCounsellor.Get(book.CounsellorID).CouncellorLastName;
            bill.CounsellorEmail = dbCounsellor.Get(book.CounsellorID).CouncellorEmail;
            
                db.Update(bill);
                TempData["Message"] = "You have succesfully saved the Bill!";
                return RedirectToAction("Details", new { id = bill.BillID });
  
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
