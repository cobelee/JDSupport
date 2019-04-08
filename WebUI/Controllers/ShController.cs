using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class ShController : Controller
    {
        private JiadianDBEntities db = new JiadianDBEntities();
        // GET: Sh
        public ActionResult Index()
        {
            return View();
        }

        // GET: Appliances/Details/5
        public ActionResult cx(string id)
        {
            if (id == null)
            {
                //return RedirectToAction("NotFoundApp");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appliance appliance = db.Appliances.FirstOrDefault(o => o.ProductSN == id);
            if (appliance == null)
            {
                return HttpNotFound();
            }
            return View(appliance);
        }
    }
}