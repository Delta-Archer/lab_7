using Lab_6.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_6.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        // GET: Home
        MobileContext db = new MobileContext();
        public ActionResult Index()
        {
            return View(db.Purchases);
        }
        public ActionResult View(int id)
        {
            var purch = db.Purchases.Find(id);
            if (purch != null)
            {
                return View(purch);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Purchases purch = db.Purchases.Find(id);
            if (purch == null)
            {
                return HttpNotFound();
            }
            return View(purch);
        }
        [HttpPost]
        public ActionResult Edit(Purchases purch)
        {
            db.Entry(purch).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Purchases purch)
        {
            db.Purchases.Add(purch);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Purchases purch = db.Purchases.Find(id);
            if (purch == null)
            {
                return HttpNotFound();
            }
            return View(purch);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Purchases purch = db.Purchases.Find(id);
            if (purch == null)
            {
                return HttpNotFound();
            }
            db.Purchases.Remove(purch);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}