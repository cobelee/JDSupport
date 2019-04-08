using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Tiyi.JD.SQLServerDAL
{
    public class BaoxiuBillDA : IDisposable
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

        ~BaoxiuBillDA()
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
        /// 获取指定状态的报修单数量
        /// </summary>
        /// <param name="isAccept">客服是否受理</param>
        /// <param name="isCompleted">报修单是否处理完毕</param>
        /// <returns></returns>
        public int GetCount(bool isAccept, bool isCompleted)
        {
            return dbContext.BaoxiuBill.Where(a => a.IsAccept == isAccept && a.IsCompleted == isCompleted).Count();
        }

        /// <summary>
        /// 创建新的报修单。
        /// </summary>
        /// <param name="newBxBill">报修单</param>
        /// <returns></returns>
        public BaoxiuBill CreateBaoxiuBill(BaoxiuBill newBaoxiuBill)
        {
            if (newBaoxiuBill == null)
                return null;

            newBaoxiuBill.BxId = Guid.NewGuid();
            newBaoxiuBill.CreateDate = DateTime.Now;
            newBaoxiuBill.IsAccept = false;
            newBaoxiuBill.IsCompleted = false;
            dbContext.BaoxiuBill.InsertOnSubmit(newBaoxiuBill);

            dbContext.SubmitChanges();

            return newBaoxiuBill;
        }

        /// <summary>
        /// 该方法供批量创建新报修单时使用
        /// <para>不立即提交数据库</para>
        /// </summary>
        /// <param name="newBaoxiuBill"></param>
        public void CreateBaoxiuBillNotSubmit(BaoxiuBill newBaoxiuBill)
        {
            if (newBaoxiuBill == null)
                return;

            newBaoxiuBill.BxId = Guid.NewGuid();
            newBaoxiuBill.CreateDate = DateTime.Now;
            newBaoxiuBill.IsAccept = false;
            newBaoxiuBill.IsCompleted = false;
            dbContext.BaoxiuBill.InsertOnSubmit(newBaoxiuBill);
        }

        /// <summary>
        /// 获取指定设备的所有报修单。
        /// </summary>
        /// <param name = "appId" > 设备Id </ param >
        /// < returns ></ returns >
        public IQueryable<BaoxiuBill> GetBaoxiuBill_ForOneApp(Guid appId)
        {
            var query = from item in dbContext.BaoxiuBill
                        where item.AppId == appId
                        orderby item.CreateDate descending
                        select item;
            return query.AsQueryable<BaoxiuBill>();
        }

        /// <summary>
        /// 获取所有未完成报修单列表。
        /// </summary>
        /// <returns></returns>
        public IQueryable<BaoxiuBill> GetBaoxiuBill_IsNotCompleted()
        {
            var query = from item in dbContext.BaoxiuBill
                        where item.IsCompleted == false
                        select item;
            return query.AsQueryable<BaoxiuBill>();
        }

        /// <summary>
        /// 判断指定报修单是否已经安排派工维修
        /// </summary>
        /// <param name="bxId">报修单Id</param>
        /// <returns></returns>
        public bool IsPaidang(Guid bxId)
        {
            bool exist = false;
            var query = from record in dbContext.PaigongBill
                        where record.BxId == bxId
                        select record;
            if (query.Count() > 0)
            {
                exist = true;
            }
            return exist;
        }


        /// <summary>
        /// 获取指定appId的报修单
        /// </summary>
        /// <param name="bxId">报修单ID</param>
        /// <returns></returns>
        public BaoxiuBill GetBaoxiuBill(Guid bxId)
        {
            var query = from item in dbContext.BaoxiuBill
                        where item.BxId == bxId
                        select item;
            BaoxiuBill bill = query.FirstOrDefault();
            return bill;
        }

        /// <summary>
        /// 根据报修单号查询对应的派工单。
        /// </summary>
        /// <param name="bxId">报修单Id</param>
        /// <returns></returns>
        public PaigongBill GetPgBill_ByBxId(Guid bxId)
        {
            var query = from item in dbContext.PaigongBill
                        where item.BxId == bxId
                        select item;
            PaigongBill bill = query.FirstOrDefault();
            return bill;
        }

        ///// <summary>
        ///// 获取审核通过，尚未报销过，且允许报销的单据。
        ///// </summary>
        ///// <returns></returns>
        //public IQueryable<BaoxiuBill> GetBills_CanBaoxiao()
        //{
        //    string agreed = Tiyi.Licai.ApprovalStatus.Agreed.ToString();
        //    var query = from item in dbContext.BaoxiuBill
        //                where item.ApproveCompleted && item.ApproveResult == agreed
        //                    && item.IsBaoxiaoed == false
        //                orderby item.ApproveDate
        //                select item;
        //    return query.AsQueryable<BaoxiuBill>();
        //}

        ///// <summary>
        ///// 获取已投资完毕的单据。
        ///// </summary>
        ///// <returns></returns>
        //public IQueryable<BaoxiuBill> GetBills_hasBaoxiaoed()
        //{
        //    var query = from item in dbContext.BaoxiuBill
        //                where item.IsBaoxiaoed == true
        //                select item;

        //    return query.AsQueryable<BaoxiuBill>();
        //}

        ///// <summary>
        ///// 保存报销申请单的审核结果数据
        ///// <para>同时将单子状态设为不可编辑，不可删除。</para>
        ///// </summary>
        ///// <param name="record">资金划转记录。</param>
        //public void SaveApprovalData(Guid bxId, string approverJobNumber, string approverRealName, string approveResult, string commentary)
        //{
        //    BaoxiuBill bill = this.GetBaoxiuBill(bxId);
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
        /// 修改报修单信息
        /// </summary>
        /// <param name="newBaoxiuBill">报修单。</param>
        public void UpdateBaoxiuBill(BaoxiuBill newBaoxiuBill)
        {
            if (newBaoxiuBill == null)
                return;
            dbContext.SubmitChanges();
        }



        /// <summary>
        /// 是否存在指定Id 报修单
        /// </summary>
        /// <param name="bxId">报修单ID</param>
        /// <returns></returns>
        public bool ExistBaoxiuBill(Guid bxId)
        {
            bool exist = false;
            var query = from record in dbContext.BaoxiuBill
                        where record.BxId == bxId
                        select record;
            if (query.Count() > 0)
            {
                exist = true;
            }
            return exist;
        }

        /// <summary>
        /// 判断是否可能是重复报修单。
        /// </summary>
        /// <param name="productSN">产品序号</param>
        /// <returns></returns>
        public bool IsRepetitiveBaoxiuBill(string productSN)
        {
            bool exist = false;
            var query = from record in dbContext.BaoxiuBill
                        where record.ProductSN == productSN
                        select record;
            if (query.Count() > 0)
            {
                exist = true;
            }
            return exist;
        }

        /// <summary>
        /// 删除指定报修单记录。
        /// </summary>
        /// <param name="appId">报修单编号 bxId .</param>
        public void DeleteBaoxiuBill(string productSN)
        {
            var query = from s in dbContext.BaoxiuBill
                        where s.ProductSN == productSN
                        select s;
            foreach (var para in query)
            {
                dbContext.BaoxiuBill.DeleteOnSubmit(para);
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

        ///// <summary>
        ///// 保存备注信息
        ///// </summary>
        ///// <param name="bxId">报修单Id</param>
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

        /// <summary>
        /// 设置报销申请单的 IsClosed 标记
        /// </summary>
        /// <param name="bxId">报修单Id</param>
        /// <param name="isCompleted">是否维修完成</param>
        public void SetMark_IsCompleted(Guid bxId, bool isCompleted)
        {
            var bill = dbContext.BaoxiuBill.FirstOrDefault(u => u.BxId == bxId);
            if (bill != null)
            {
                bill.IsCompleted = isCompleted;
                dbContext.SubmitChanges();
            }
        }

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
