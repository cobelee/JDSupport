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
    public class BaoxiuBillsController : Controller
    {
        private JiadianDBEntities db = new JiadianDBEntities();
        Tiyi.Weixin.Work.SendMsgService ws_wxSender = new Tiyi.Weixin.Work.SendMsgService();

        // GET: BaoxiuBills
        public ActionResult Index()
        {
            var baoxiuBills = db.BaoxiuBills.Include(b => b.Appliance);
            return View(baoxiuBills.ToList());
        }

        /// <summary>
        /// 指定设备 所有的报修记录列表
        /// </summary>
        /// <param name="id">设备管理号 ProductSN</param>
        /// <returns></returns>
        public ActionResult BillList(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<BaoxiuBill> baoxiuBills = db.BaoxiuBills.Where(m => m.ProductSN == id).OrderByDescending(o => o.CreateDate).ToList();
            foreach (BaoxiuBill b in baoxiuBills)
            {
                b.BillStatus = b.BillStatus + "(前面等待" + GetCountOfBill_Front(b).ToString() + "单)";
            }
            ViewBag.ProductSN = id;
            return View(baoxiuBills);
        }

        // GET: BaoxiuBills/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoxiuBill baoxiuBill = db.BaoxiuBills.Find(id);
            if (baoxiuBill == null)
            {
                return HttpNotFound();
            }
            return View(baoxiuBill);
        }

        // GET: BaoxiuBills/Create
        //public ActionResult Create()
        //{
        //    ViewBag.AppId = new SelectList(db.Appliances, "AppId", "ProductSN");
        //    return View();
        //}

        public ActionResult Create(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appliance appliance = db.Appliances.FirstOrDefault(o => o.ProductSN == id);
            if (appliance == null)
            {
                return HttpNotFound();
            }
            ViewBag.Appliance = appliance;
            ViewBag.AppId = new SelectList(db.Appliances, "AppId", "ProductSN");
            return View(appliance);
        }

        // POST: BaoxiuBills/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        public ActionResult Create([Bind(Include = "BxId,AppId,ProductSN,BigClass,AppType,DepName,Address,UserName,UserMobilePhone,UserMobileShort,FaultPhenomenon,CreateDate,HandleResult,IsAccept")] BaoxiuBill baoxiuBill)
        {
            if (ModelState.IsValid)
            {
                baoxiuBill.BxId = Guid.NewGuid();
                baoxiuBill.CreateDate = DateTime.Now;
                baoxiuBill.BillStatus = "等待派工";
                baoxiuBill.IsAccept = false;
                db.BaoxiuBills.Add(baoxiuBill);
                db.SaveChanges();
                SendWxToAdmin(baoxiuBill);
                return RedirectToAction("CreateSuccess", new { id = baoxiuBill.ProductSN });
            }

            ViewBag.AppId = new SelectList(db.Appliances, "AppId", "ProductSN", baoxiuBill.AppId);
            return View(baoxiuBill);
        }



        public ActionResult CreateSuccess(string id)
        {
            ViewBag.ProductSN = id;
            return View();
        }

        // GET: BaoxiuBills/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Baoxiu-Bill-Id is not identified.");

            }
            BaoxiuBill baoxiuBill = db.BaoxiuBills.Find(id);
            if (baoxiuBill == null)
            {
                return HttpNotFound("Can't find Baoxiu-Bill.");
            }
            return View(baoxiuBill);
        }

        // POST: BaoxiuBills/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BxId,AppId,ProductSN,BigClass,AppType,DepName,Address,UserName,UserMobilePhone,UserMobileShort,FaultPhenomenon,CreateDate,HandleResult,IsAccept")] BaoxiuBill baoxiuBill)
        {
            if (ModelState.IsValid)
            {
                baoxiuBill.CreateDate = DateTime.Now;
                db.Entry(baoxiuBill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BillList", new { id = baoxiuBill.ProductSN });
            }
            ViewBag.AppId = new SelectList(db.Appliances, "AppId", "ProductSN", baoxiuBill.AppId);
            return View(baoxiuBill);
        }

        // GET: BaoxiuBills/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoxiuBill baoxiuBill = db.BaoxiuBills.Find(id);
            if (baoxiuBill == null)
            {
                return HttpNotFound();
            }
            return View(baoxiuBill);
        }

        // POST: BaoxiuBills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            BaoxiuBill baoxiuBill = db.BaoxiuBills.Find(id);
            db.BaoxiuBills.Remove(baoxiuBill);
            db.SaveChanges();
            return RedirectToAction("BillList", new { id = baoxiuBill.ProductSN });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 本类私有方法

        private void SendWxToAdmin(BaoxiuBill bxBill)
        {
            Tiyi.Weixin.Work.Article article = new Tiyi.Weixin.Work.Article();
            article.Title = "设备故障报修";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("设备管理号：" + bxBill.ProductSN);
            sb.AppendLine("设备类型：" + bxBill.BigClass + bxBill.AppType);
            sb.AppendLine("详细地址：" + bxBill.DepName + bxBill.Address);
            sb.AppendLine("用户信息：" + bxBill.UserName + " " + bxBill.UserMobilePhone);
            sb.AppendLine("炼化短号：" + bxBill.UserMobileShort + "\n");
            sb.AppendLine("报障时间：" + DateTime.Now.ToString());
            sb.AppendLine("故障现象：" + bxBill.FaultPhenomenon);
            sb.AppendLine("备注信息：" + bxBill.Remark);

            sb.AppendLine("\n请客服尽快电话联系客户，确认故障，根据情况下达派工单。");
            article.Description = sb.ToString();
            article.Url = "";
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string articleJson = js.Serialize(article);
            try
            {
                // Tags = 8, 标签：家电售后服务 |  AgentId="1000002" APP：空调维修保养  |  AgentId="34" APP：消息通知
                ws_wxSender.SendArticleToTags("8", articleJson, "34");
            }
            catch (Exception ee)
            {

            }
        }

        /// <summary>
        /// 计算排在本单前面的尚未处理的单据
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        private int GetCountOfBill_Front(BaoxiuBill bill)
        {
            int count = 0;
            var bills = from b in db.BaoxiuBills
                        where b.CreateDate < bill.CreateDate && b.IsCompleted == false && b.IsAccept == false
                        select b;
            if (bills != null)
                count = bills.Count();

            return count;
        }
        #endregion
    }
}
