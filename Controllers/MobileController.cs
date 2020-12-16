using Lab_6.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Lab_6.Controllers
{
    [Authorize]
    public class MobileController : Controller
    {
        // GET: Mobile
        MobileContext db = new MobileContext();
        public ActionResult Index()
        {
            var mobiles = db.Mobiles.Include(p => p.Company);
            return View(mobiles.ToList());
        }

        public ActionResult View(int id)
        {
            var mob = db.Mobiles.Find(id);
            if (mob != null)
            {
                return View(mob);
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
            Mobiles mob = db.Mobiles.Find(id);
            if (mob == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", mob.CompanyId);
            return View(mob);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Model,Price,CompanyId")] Mobiles mob)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mob).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", mob.CompanyId);
            return View(mob);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SelectList companies = new SelectList(db.Companies, "Id", "Name");
            ViewBag.Companies = companies;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Model,Price,CompanyId")] Mobiles mob)
        {
            if (ModelState.IsValid)
            {
                db.Mobiles.Add(mob);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", mob.CompanyId);
            return View(mob);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Mobiles mob = db.Mobiles.Find(id);
            if (mob == null)
            {
                return HttpNotFound();
            }
            return View(mob);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Mobiles mob = db.Mobiles.Find(id);
            if (mob == null)
            {
                return HttpNotFound();
            }
            db.Mobiles.Remove(mob);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}