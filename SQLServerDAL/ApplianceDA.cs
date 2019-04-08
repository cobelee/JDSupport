using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Tiyi.JD.SQLServerDAL
{
    public class ApplianceDA : IDisposable
    {
        JiadianDataContext dbContext = new JiadianDataContext(Tiyi.JD.SQLServerDAL.Connection.GetConnectionString());

        /// <summary>
        /// 释放由本类占用的所有资源
        /// </summary>
        public void Dispose()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
                dbContext = null;
            }

            GC.SuppressFinalize(this);
        }

        ~ApplianceDA()
        {
            this.Dispose();
        }

        /// <summary>
        /// 对对象的更改提交至数据，使其生效
        /// </summary>
        public void SubmitChanges()
        {
            if (dbContext != null)
                dbContext.SubmitChanges();
        }

        /// <summary>
        /// 获取设备总数
        /// </summary>
        /// <returns></returns>
        public int GetCount_Appliance()
        {
            int count = 0;
            count = dbContext.Appliance.Where(a => a.IsScrapped == false).Count();
            return count;
        }

        /// <summary>
        /// 创建新的设备。
        /// </summary>
        /// <param name="newBxBill">设备</param>
        /// <returns></returns>
        public Appliance CreateAppliance(Appliance newAppliance)
        {
            if (newAppliance == null)
                return null;

            newAppliance.AppId = Guid.NewGuid();
            newAppliance.IsScrapped = false;
            newAppliance.IsUsing = true;
            dbContext.Appliance.InsertOnSubmit(newAppliance);

            dbContext.SubmitChanges();

            return newAppliance;
        }

        /// <summary>
        /// 该方法供批量创建新设备时使用
        /// <para>不立即提交数据库</para>
        /// </summary>
        /// <param name="newAppliance"></param>
        public void CreateApplianceNotSubmit(Appliance newAppliance)
        {
            if (newAppliance == null)
                return;

            newAppliance.AppId = Guid.NewGuid();
            newAppliance.IsScrapped = false;
            newAppliance.IsUsing = true;
            dbContext.Appliance.InsertOnSubmit(newAppliance);
        }

        /// <summary>
        /// 获取我的最近10条设备。
        /// </summary>
        /// <param name="investorID">我的工号</param>
        /// <returns></returns>
        //public IQueryable<Appliance> GetMyApplianceTop10(string investorID)
        //{
        //    var query = from item in dbContext.Appliance
        //                where item.InvestorID == investorID
        //                orderby item.InvestDate descending
        //                select item;
        //    return query.AsQueryable<Appliance>().Take(10);
        //}

        /// <summary>
        /// 获取在用设备列表。
        /// </summary>
        /// <returns></returns>
        public IQueryable<Appliance> GetAppliance_IsUsing()
        {
            var query = from item in dbContext.Appliance
                        where item.IsUsing == true
                        select item;
            return query.AsQueryable<Appliance>();
        }

        /// <summary>
        /// 获取我的今日到期且未回款的设备。
        /// </summary>
        /// <param name="investorID">我的工号</param>
        /// <returns></returns>
        //public IQueryable<Appliance> GetMyAppliance_Overdue(string investorID)
        //{
        //    var query = from item in dbContext.Appliance
        //                where item.InvestorID == investorID && item.IsTakeBack == false && item.DueDate.Value.Date < DateTime.Now.Date
        //                select item;
        //    return query.AsQueryable<Appliance>();
        //}

        /// <summary>
        /// 获取指定appId的设备
        /// </summary>
        /// <param name="appId">设备ID</param>
        /// <returns></returns>
        public Appliance GetAppliance(Guid appId)
        {
            var query = from item in dbContext.Appliance
                        where item.AppId == appId
                        select item;
            Appliance bill = query.FirstOrDefault();
            return bill;
        }

        /// <summary>
        /// 获取指定appId的设备
        /// </summary>
        /// <param name="productSN">设备ID</param>
        /// <returns></returns>
        public Appliance GetAppliance(string productSN)
        {
            var query = from item in dbContext.Appliance
                        where item.ProductSN == productSN
                        select item;
            Appliance bill = query.FirstOrDefault();
            return bill;
        }

        /// <summary>
        /// 获取所有的设备所属公司名称列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<String> GetCorpNameList()
        {
            var query = dbContext.Appliance.GroupBy(p => p.OwnerDepName).Select(g => g.FirstOrDefault().OwnerDepName);
            return query.AsQueryable<String>();
        }

        /// <summary>
        /// 获取指定产品大类的设备所属公司名称列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<String> GetCorpNameList(string bigClass)
        {
            var query = dbContext.Appliance.Where(o => o.BigClass == bigClass).GroupBy(p => p.OwnerDepName).Select(g => g.FirstOrDefault().OwnerDepName);
            return query.AsQueryable<String>();
        }

        ///// <summary>
        ///// 获取审核通过，尚未报销过，且允许报销的单据。
        ///// </summary>
        ///// <returns></returns>
        //public IQueryable<Appliance> GetBills_CanBaoxiao()
        //{
        //    string agreed = Tiyi.Licai.ApprovalStatus.Agreed.ToString();
        //    var query = from item in dbContext.Appliance
        //                where item.ApproveCompleted && item.ApproveResult == agreed
        //                    && item.IsBaoxiaoed == false
        //                orderby item.ApproveDate
        //                select item;
        //    return query.AsQueryable<Appliance>();
        //}

        ///// <summary>
        ///// 获取已投资完毕的单据。
        ///// </summary>
        ///// <returns></returns>
        //public IQueryable<Appliance> GetBills_hasBaoxiaoed()
        //{
        //    var query = from item in dbContext.Appliance
        //                where item.IsBaoxiaoed == true
        //                select item;

        //    return query.AsQueryable<Appliance>();
        //}

        ///// <summary>
        ///// 保存报销申请单的审核结果数据
        ///// <para>同时将单子状态设为不可编辑，不可删除。</para>
        ///// </summary>
        ///// <param name="record">资金划转记录。</param>
        //public void SaveApprovalData(Guid bxId, string approverJobNumber, string approverRealName, string approveResult, string commentary)
        //{
        //    Appliance bill = this.GetAppliance(bxId);
        //    if (bill == null)
        //        return;

        //    bill.ApproverJobNumber = approverJobNumber;
        //    bill.ApproverRealName = approverRealName;
        //    bill.ApproveResult = approveResult;
        //    bill.Commentary = commentary;
        //    bill.ApproveDate = DateTime.Now;
        //    bill.ApproveCompleted = true;
        //    bill.CurrentStatus = "审核完毕";
        //    bill.CanEdit = false;
        //    bill.CanDelete = false;
        //    dbContext.SubmitChanges();
        //}


        /// <summary>
        /// 修改设备信息
        /// </summary>
        /// <param name="newAppliance">设备。</param>
        public void UpdateAppliance(Appliance newAppliance)
        {
            if (newAppliance == null)
                return;
            dbContext.SubmitChanges();
        }



        /// <summary>
        /// 是否存在指定Id 设备
        /// </summary>
        /// <param name="appId">设备ID</param>
        /// <returns></returns>
        public bool ExistAppliance(Guid appId)
        {
            bool exist = false;
            var query = from record in dbContext.Appliance
                        where record.AppId == appId
                        select record;
            if (query.Count() > 0)
            {
                exist = true;
            }
            return exist;
        }

        /// <summary>
        /// 判断是否可能是重复设备。
        /// </summary>
        /// <param name="productSN">产品序号</param>
        /// <returns></returns>
        public bool IsRepetitiveAppliance(string productSN)
        {
            bool exist = false;
            var query = from record in dbContext.Appliance
                        where record.ProductSN == productSN
                        select record;
            if (query.Count() > 0)
            {
                exist = true;
            }
            return exist;
        }

        /// <summary>
        /// 删除指定设备记录。
        /// </summary>
        /// <param name="appId">设备编号 bxId .</param>
        public void DeleteAppliance(string productSN)
        {
            var query = from s in dbContext.Appliance
                        where s.ProductSN == productSN
                        select s;
            foreach (var para in query)
            {
                dbContext.Appliance.DeleteOnSubmit(para);
            }

            try
            {
                dbContext.SubmitChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 删除指定设备记录。
        /// By AppId.
        /// </summary>
        /// <param name="appId">设备系统Id.</param>
        public void DeleteAppliance(Guid appId)
        {
            var query = from s in dbContext.Appliance
                        where s.AppId == appId
                        select s;
            foreach (var para in query)
            {
                dbContext.Appliance.DeleteOnSubmit(para);
            }

            try
            {
                dbContext.SubmitChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 回收投资
        /// </summary>
        /// <param name="appId">设备IdId.</param>
        /// <param name="scrapDate">实际收回收益.</param>
        public void ScrapAppliance(Guid appId, DateTime? scrapDate)
        {
            Appliance record = this.GetAppliance(appId);
            record.ScrapDate = scrapDate ?? DateTime.Now;
            record.IsScrapped = true;
            dbContext.SubmitChanges();
        }

        ///// <summary>
        ///// 保存备注信息
        ///// </summary>
        ///// <param name="bxId">设备Id</param>
        ///// <param name="remark"></param>
        //public void SaveDescription(Guid bxId, string remark)
        //{
        //    BxBill bill = this.GetBxBill(bxId);
        //    bill.Description = remark;
        //    dbContext.SubmitChanges();
        //}

        ///// <summary>
        ///// 设置投资申请单的 Submitted 标记
        ///// </summary>
        ///// <param name="bxId">单据Id</param>
        ///// <param name="submitted">申请单的关闭标记</param>
        //public void SetMark_Submitted(Guid bxId, bool submitted)
        //{
        //    BxBill bill = this.GetBxBill(bxId);
        //    if (bill != null)
        //    {
        //        bill.Submitted = submitted;
        //        dbContext.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
        //    }
        //}

        ///// <summary>
        ///// 设置报销申请单的 Classified 标记
        ///// </summary>
        ///// <param name="bxId">单据Id</param>
        ///// <param name="classified">申请单的关闭标记</param>
        //public void SetMark_Classified(Guid bxId, bool classified)
        //{
        //    BxBill bill = this.GetBxBill(bxId);
        //    if (bill != null)
        //    {
        //        bill.Classified = classified;
        //        dbContext.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
        //    }
        //}

        ///// <summary>
        ///// 设置报销申请单的 CanEdit 标记
        ///// </summary>
        ///// <param name="bxId">单据Id</param>
        ///// <param name="canEdit">申请单的关闭标记</param>
        //public void SetMark_CanEdit(Guid bxId, bool canEdit)
        //{
        //    BxBill bill = this.GetBxBill(bxId);
        //    if (bill != null)
        //    {
        //        bill.CanEdit = canEdit;
        //        dbContext.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
        //    }
        //}

        ///// <summary>
        ///// 设置报销申请单的 canDelete 标记
        /////  <para>需要submitChanges才能生效。</para>
        ///// </summary>
        ///// <param name="bxId">单据Id</param>
        ///// <param name="canDelete">票据的关闭标记</param>
        //public void SetMark_CanDelete(Guid bxId, bool canDelete)
        //{
        //    var bill = dbContext.BxBill.FirstOrDefault(u => u.BxId == bxId);
        //    if (bill != null)
        //        bill.CanDelete = canDelete;
        //}

        ///// <summary>
        ///// 设置报销申请单的 IsClosed 标记
        ///// <para>需要submitChanges才能生效。</para>
        ///// </summary>
        ///// <param name="bxId">单据Id</param>
        ///// <param name="isClosed">票据的关闭标记</param>
        //private void SetMark_IsClosed(Guid bxId, bool isClosed)
        //{
        //    var bill = dbContext.BxBill.FirstOrDefault(u => u.BxId == bxId);
        //    if (bill != null)
        //        bill.IsClosed = isClosed;
        //}

        ///// <summary>
        ///// 将报销申请单 设置为 报销完毕的状态。
        ///// <para>报销标记设为 True</para>
        ///// <para>关闭标记设为 True</para>
        ///// </summary>
        ///// <param name="bxId">单据Id</param>
        //public void SetTo报销完毕(Guid bxId)
        //{
        //    var bill = dbContext.BxBill.FirstOrDefault(u => u.BxId == bxId);
        //    if (bill != null)
        //    {
        //        bill.IsBaoxiaoed = true;
        //        bill.IsClosed = true;
        //        bill.CurrentStatus = "报销完毕";
        //        dbContext.SubmitChanges();
        //    }
        //}

        ///// <summary>
        ///// 更新报销申请单的状态信息
        ///// </summary>
        ///// <param name="bxId">报销申请单Id</param>
        ///// <param name="currentStatus">当前状态信息</param>
        //public void ChangeStatusInfo(Guid bxId, string currentStatus)
        //{
        //    var bill = dbContext.BxBill.FirstOrDefault(u => u.BxId == bxId);
        //    if (bill != null)
        //    {
        //        bill.CurrentStatus = currentStatus;
        //        dbContext.SubmitChanges();
        //    }
        //}

        ///// <summary>
        ///// 关闭报销业务。
        ///// </summary>
        ///// <param name="bxId">报销Id</param>
        //public void CloseBill(System.Guid bxId)
        //{
        //    SetMark_IsClosed(bxId, true);
        //    dbContext.SubmitChanges();
        //}
    }
}
