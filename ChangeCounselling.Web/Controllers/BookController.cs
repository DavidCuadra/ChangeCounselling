﻿using ChangeCounselling.Data.Models;
using ChangeCounselling.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChangeCounselling.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookData db;
        private readonly IClientData dbClient;
        private readonly ICounsellorData dbCounsellor;
        private readonly IBillData dbBill;


        public BookController(IBookData db, IClientData dbClient, ICounsellorData dbCounsellor, IBillData dbBill)
        {
            this.db = db;
            this.dbClient = dbClient;
            this.dbCounsellor = dbCounsellor;
            this.dbBill = dbBill;

        }


        // GET: Book
        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            
            var db = new SqlClientData(new CounsellorDbContext());
            var result = db.GetAll().ToList();

            var db1 = new SqlCounsellorData(new CounsellorDbContext());
            var result1 = db1.GetAll().ToList();

            ViewBag.data = result;
            ViewBag.data1 = result1;
            return View();
        }

        public ActionResult CreateBill(int id)
        {

            var book = this.db.Get(id);
            Bill bill = new Bill()
            {
                DateTime = DateTime.Now,
                BookID = id,
                ClientFirstName = dbClient.Get(book.ClientID).ClientFirstName,
                ClientLastName = dbClient.Get(book.ClientID).ClientLastName,
                ClientEmail = dbClient.Get(book.ClientID).ClientEmail,
                CounsellorFirstName = dbCounsellor.Get(book.CounsellorID).CouncellorFirstName,
                CounsellorLastName = dbCounsellor.Get(book.CounsellorID).CouncellorLastName,
                CounsellorEmail = dbCounsellor.Get(book.CounsellorID).CouncellorEmail
            };
            dbBill.Add(bill);

            return RedirectToAction("Index", "Bill");
        }



        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
                if (ModelState.IsValid)
                {
                    db.Add(book);
                    return RedirectToAction("Details", new { id = book.BookID });
                }
            var dbC = new SqlClientData(new CounsellorDbContext());
            var result = dbC.GetAll().ToList();

            var db1 = new SqlCounsellorData(new CounsellorDbContext());
            var result1 = db1.GetAll().ToList();

            ViewBag.data = result;
            ViewBag.data1 = result1;
            return View();
        }

        // GET: Book/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new SqlClientData(new CounsellorDbContext());
            var result = db.GetAll().ToList();

            var db1 = new SqlCounsellorData(new CounsellorDbContext());
            var result1 = db1.GetAll().ToList();

            ViewBag.data = result;
            ViewBag.data1 = result1;
      

            var model =this.db.Get(id);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }





        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Update(book);
                TempData["Message"] = "You have succesfully updated your booking!";
                return RedirectToAction("Details", new { id = book.BookID});
            }

            var dbC = new SqlClientData(new CounsellorDbContext());
            var result = dbC.GetAll().ToList();

            var db1 = new SqlCounsellorData(new CounsellorDbContext());
            var result1 = db1.GetAll().ToList();

            ViewBag.data = result;
            ViewBag.data1 = result1;
            return View(book);
        }

        // GET: Book/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        // POST: Book/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Book book)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
