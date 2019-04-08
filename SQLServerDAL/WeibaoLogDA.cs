using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Tiyi.JD.SQLServerDAL
{
    public class WeibaoLogDA : IDisposable
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

        ~WeibaoLogDA()
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
        /// 创建新的维保记录。
        /// </summary>
        /// <param name="newBxBill">维保记录</param>
        /// <returns></returns>
        public WeibaoLog CreateWeibaoLog(WeibaoLog newWeibaoLog)
        {
            if (newWeibaoLog == null)
                return null;

            newWeibaoLog.WbId = Guid.NewGuid();
            newWeibaoLog.CreateDate = System.DateTime.Now;
            newWeibaoLog.WbDate = DateTime.Now;
            dbContext.WeibaoLog.InsertOnSubmit(newWeibaoLog);

            dbContext.SubmitChanges();

            return newWeibaoLog;
        }

        /// <summary>
        /// 该方法供批量创建新维保记录时使用
        /// <para>不立即提交数据库</para>
        /// </summary>
        /// <param name="newWeibaoLog"></param>
        public void CreateWeibaoLogNotSubmit(WeibaoLog newWeibaoLog)
        {
            if (newWeibaoLog == null)
                return;

            newWeibaoLog.WbId = Guid.NewGuid();
            newWeibaoLog.CreateDate = System.DateTime.Now;
            dbContext.WeibaoLog.InsertOnSubmit(newWeibaoLog);
        }

        /// <summary>
        /// 获取指定appId的维保记录
        /// </summary>
        /// <param name="appId">设备ID</param>
        /// <returns></returns>
        public IQueryable<WeibaoLog> GetWeibaoLog(Guid appId)
        {
            var query = from item in dbContext.WeibaoLog
                        where item.AppId == appId
                        orderby item.CreateDate descending
                        select item;
            return query.AsQueryable<WeibaoLog>();
        }

        /// <summary>
        /// 获取指定appId的最近一次维保记录
        /// </summary>
        /// <param name="appId">设备ID</param>
        /// <returns></returns>
        public WeibaoLog GetLastWeibaoLog(Guid appId)
        {
            var query = dbContext.WeibaoLog.OrderByDescending(u=>u.WbDate).FirstOrDefault(o => o.AppId == appId);
            return query;
        }


        /// <summary>
        /// 修改维保记录信息
        /// </summary>
        /// <param name="newWeibaoLog">维保记录。</param>
        public void UpdateWeibaoLog(WeibaoLog newWeibaoLog)
        {
            if (newWeibaoLog == null)
                return;
            dbContext.SubmitChanges();
        }



        /// <summary>
        /// 是否存在指定Id 维保记录
        /// </summary>
        /// <param name="appId">维保记录ID</param>
        /// <returns></returns>
        public bool ExistWeibaoLog(Guid appId)
        {
            bool exist = false;
            var query = from record in dbContext.WeibaoLog
                        where record.AppId == appId
                        select record;
            if (query.Count() > 0)
            {
                exist = true;
            }
            return exist;
        }

        /// <summary>
        /// 判断是否可能是重复维保记录。
        /// </summary>
        /// <param name="productSN">产品序号</param>
        /// <returns></returns>
        public bool IsRepetitiveWeibaoLog(string productSN)
        {
            bool exist = false;
            var query = from record in dbContext.WeibaoLog
                        where record.ProductSN == productSN
                        select record;
            if (query.Count() > 0)
            {
                exist = true;
            }
            return exist;
        }

        /// <summary>
        /// 删除指定维保记录记录。
        /// </summary>
        /// <param name="wbId">维保记录编号 wbId .</param>
        public void DeleteWeibaoLog(Guid wbId)
        {
            var query = from s in dbContext.WeibaoLog
                        where s.WbId == wbId
                        select s;
            foreach (var para in query)
            {
                dbContext.WeibaoLog.DeleteOnSubmit(para);
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
        ///// <param name="bxId">维保记录Id</param>
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
