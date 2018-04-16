using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class UploadDataController : Controller
    {
        private JiadianDBEntities db = new JiadianDBEntities();
        // GET: UploadData
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Update()
        {
            Appliance appliance = db.Appliances.FirstOrDefault(o => o.ProductSN == "1000");
            appliance.PowerCold = "2001";
            db.SaveChanges();
            return View();
        }
    }
}