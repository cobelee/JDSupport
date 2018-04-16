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
    public class ProductSNsController : Controller
    {
        private JiadianDBEntities db = new JiadianDBEntities();

        // GET: ProductSNs
        public ActionResult Index()
        {
            return View(db.ProductSNs.ToList());
        }

        // GET: ProductSNs/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSN productSN = db.ProductSNs.Find(id);
            if (productSN == null)
            {
                return HttpNotFound();
            }
            return View(productSN);
        }

        // GET: ProductSNs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductSNs/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SN,CreateDate,ActiveTime,Downtime,ActiveStatus")] ProductSN productSN)
        {
            if (ModelState.IsValid)
            {
                productSN.Id = Guid.NewGuid();
                productSN.CreateDate = DateTime.Now;
                db.ProductSNs.Add(productSN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productSN);
        }

        // GET: ProductSNs/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSN productSN = db.ProductSNs.Find(id);
            if (productSN == null)
            {
                return HttpNotFound();
            }
            return View(productSN);
        }

        // POST: ProductSNs/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SN,CreateDate,ActiveTime,Downtime,ActiveStatus")] ProductSN productSN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productSN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productSN);
        }

        // GET: ProductSNs/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSN productSN = db.ProductSNs.Find(id);
            if (productSN == null)
            {
                return HttpNotFound();
            }
            return View(productSN);
        }

        // POST: ProductSNs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ProductSN productSN = db.ProductSNs.Find(id);
            db.ProductSNs.Remove(productSN);
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
    }
}
