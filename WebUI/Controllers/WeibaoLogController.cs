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
    public class WeibaoLogController : Controller
    {
        private JiadianDBEntities db = new JiadianDBEntities();
        // GET: WeibaoLog
        public ActionResult Index()
        {
            return View();
        }

        // GET: Appliances/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeibaoLog/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "AppId, WbContent, Remark, WbJobNumber, WbRealName")] WeibaoLog log)
        {
            if (ModelState.IsValid)
            {
                Appliance app = db.Appliances.First(o => o.AppId == log.AppId);
                log.FixedSN = app.FixedSN;
                log.AssetSN = app.AssetSN;
                log.ProductSN = app.ProductSN;
                log.BigClass = app.BigClass;
                log.AppType = app.AppType;
                log.OwerDepName = app.OwnerDepName;
                log.Address = app.Address;
                log.AppId = Guid.NewGuid();
                db.WeibaoLogs.Add(log);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(log);
        }

        /// <summary>
        /// 获取指定设备的历年维保记录
        /// </summary>
        /// <param name="id">设备管理号 ProductSN</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult WbLogList(string id)
        {
            if (id == null)
            {
                //return RedirectToAction("NotFoundApp");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<WeibaoLog> wbLogs = db.WeibaoLogs.Where(o => o.ProductSN == id).OrderByDescending(o => o.CreateDate).ToList();
            ViewBag.ProductSN = id;
            return View(wbLogs);
        }
    }
}