using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebUI;

namespace WebUI.Controllers
{
    public class AppliancesController : Controller
    {
        private JiadianDBEntities db = new JiadianDBEntities();

        // GET: Appliances
        public ActionResult Index()
        {
            return View(db.Appliances.ToList());
        }

        // GET: Appliances/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appliance appliance = db.Appliances.Find(id);
            if (appliance == null)
            {
                return HttpNotFound();
            }
            return View(appliance);
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

        // GET: Appliances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appliances/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppId, BigClass, ProductSN,AppName,AppType,Model,PowerCold,PowerHot,Factory,ProductDate,InstallationDate,ScrapDate,IsScrapped,IsUsing")] Appliance appliance)
        {
            if (ModelState.IsValid)
            {
                appliance.AppId = Guid.NewGuid();
                db.Appliances.Add(appliance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appliance);
        }

        // GET: Appliances/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appliance appliance = db.Appliances.Find(id);
            if (appliance == null)
            {
                return HttpNotFound();
            }
            return View(appliance);
        }

        // POST: Appliances/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppId, BigClass, ProductSN,AppName,AppType,Model,PowerCold,PowerHot,Factory,ProductDate,InstallationDate,ScrapDate,IsScrapped,IsUsing")] Appliance appliance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appliance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appliance);
        }

        // GET: Appliances/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appliance appliance = db.Appliances.Find(id);
            if (appliance == null)
            {
                return HttpNotFound();
            }
            return View(appliance);
        }

        // POST: Appliances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Appliance appliance = db.Appliances.Find(id);
            db.Appliances.Remove(appliance);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// 未找到设备管理号时，引导到此控制器
        /// </summary>
        /// <returns></returns>
        public ActionResult NotFoundApp()
        {
            return View();
        }

    }
}
