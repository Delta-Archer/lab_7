using Lab_6.Models;
using System.Linq;
using System.Web.Mvc;

namespace Lab_6.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        // GET: Company
        MobileContext db = new MobileContext();
        public ActionResult Index()
        {
            return View(db.Companies);
        }
        public ActionResult CompanyDetails(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Companies comp = db.Companies.Find(id);
            if (comp == null)
            {
                return HttpNotFound();
            }
            comp.Mobiles = db.Mobiles.Where(m => m.CompanyId == comp.Id);
            return View(comp);
        }
    }
}