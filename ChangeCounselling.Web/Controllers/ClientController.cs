using ChangeCounselling.Data.Models;
using ChangeCounselling.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChangeCounselling.Web.Controllers
{
    public class ClientController : Controller
    {

        private readonly IClientData db;

        public ClientController(IClientData db)
        {
            this.db = db;
        }
        //Get Clients
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
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            if(ModelState.IsValid)
            {
               
                db.Add(client);
                return RedirectToAction("Details", new { id = client.ClientID });
            }
            return View(client);
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
        public ActionResult Edit (Client client)
        {
            if (ModelState.IsValid)
            {
                db.Update(client);
                TempData["Message"] = "You have succesfully saved the Client!";
                return RedirectToAction("Details", new { id = client.ClientID });
            }
            return View(client);
        }

        [HttpGet]
        public ActionResult Delete (int id)
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
        public ActionResult Delete (int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction ("Index");
        }
    }
}