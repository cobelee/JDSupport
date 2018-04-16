using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Tiyi.JD.SQLServerDAL
{
    public class PaigongBillDA : IDisposable
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

        ~PaigongBillDA()
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
        /// 创建新的派工单。
        /// </summary>
        /// <param name="newBxBill">派工单</param>
        /// <returns></returns>
        public PaigongBill CreatePaigongBill(PaigongBill newPaigongBill)
        {
            if (newPaigongBill == null)
                return null;

            newPaigongBill.PgId = Guid.NewGuid();
            newPaigongBill.CreateDate = DateTime.Now;
            newPaigongBill.IsClosed = false;
            dbContext.PaigongBill.InsertOnSubmit(newPaigongBill);

            dbContext.SubmitChanges();

            return newPaigongBill;
        }

        /// <summary>
        /// 该方法供批量创建新派工单时使用
        /// <para>不立即提交数据库</para>
        /// </summary>
        /// <param name="newPaigongBill"></param>
        public void CreatePaigongBillNotSubmit(PaigongBill newPaigongBill)
        {
            if (newPaigongBill == null)
                return;

            newPaigongBill.PgId = Guid.NewGuid();
            newPaigongBill.CreateDate = DateTime.Now;
            newPaigongBill.IsClosed = false;

            dbContext.PaigongBill.InsertOnSubmit(newPaigongBill);
        }

        /// <summary>
        /// 获取我的最近10条派工单。
        /// </summary>
        /// <param name="investorID">我的工号</param>
        /// <returns></returns>
        //public IQueryable<PaigongBill> GetMyPaigongBillTop10(string investorID)
        //{
        //    var query = from item in dbContext.PaigongBill
        //                where item.InvestorID == investorID
        //                orderby item.InvestDate descending
        //                select item;
        //    return query.AsQueryable<PaigongBill>().Take(10);
        //}

        /// <summary>
        /// 获取所有未完成派工单列表。
        /// </summary>
        /// <returns></returns>
        public IQueryable<PaigongBill> GetPaigongBill_IsNotClosed()
        {
            var query = from item in dbContext.PaigongBill
                        where item.IsClosed == false
                        select item;
            return query.AsQueryable<PaigongBill>();
        }


        /// <summary>
        /// 获取指定appId的派工单
        /// </summary>
        /// <param name="pgId">派工单ID</param>
        /// <returns></returns>
        public PaigongBill GetPaigongBill(Guid pgId)
        {
            var query = from item in dbContext.PaigongBill
                        where item.PgId == pgId
                        select item;
            PaigongBill bill = query.FirstOrDefault();
            return bill;
        }


        /// <summary>
        /// 修改派工单信息
        /// </summary>
        /// <param name="newPaigongBill">派工单。</param>
        public void UpdatePaigongBill(PaigongBill newPaigongBill)
        {
            if (newPaigongBill == null)
                return;
            dbContext.SubmitChanges();
        }



        /// <summary>
        /// 是否存在指定Id 派工单
        /// </summary>
        /// <param name="pgId">派工单ID</param>
        /// <returns></returns>
        public bool ExistPaigongBill(Guid pgId)
        {
            bool exist = false;
            var query = from record in dbContext.PaigongBill
                        where record.PgId == pgId
                        select record;
            if (query.Count() > 0)
            {
                exist = true;
            }
            return exist;
        }

        /// <summary>
        /// 判断是否可能是重复派工单。
        /// </summary>
        /// <param name="productSN">产品序号</param>
        /// <returns></returns>
        //public bool IsRepetitivePaigongBill(string productSN)
        //{
        //    bool exist = false;
        //    var query = from record in dbContext.PaigongBill
        //                where record.ProductSN == productSN
        //                select record;
        //    if (query.Count() > 0)
        //    {
        //        exist = true;
        //    }
        //    return exist;
        //}

        /// <summary>
        /// 删除指定派工单记录。
        /// </summary>
        /// <param name="appId">派工单编号 pgId .</param>
        public void DeletePaigongBill(string productSN)
        {
            var query = from s in dbContext.PaigongBill
                        where s.ProductSN == productSN
                        select s;
            foreach (var para in query)
            {
                dbContext.PaigongBill.DeleteOnSubmit(para);
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
        /// 设置报销申请单的 IsClosed 标记
        /// </summary>
        /// <param name="pgId">派工单Id</param>
        /// <param name="isClosed">是否维修完成</param>
        public void SetMark_IsClosed(Guid pgId, bool isClosed)
        {
            var bill = dbContext.PaigongBill.FirstOrDefault(u => u.PgId == pgId);
            if (bill != null)
            {
                bill.IsClosed = isClosed;
                dbContext.SubmitChanges();
            }
        }

        /// <summary>
        /// 关闭报销业务。
        /// </summary>
        /// <param name="pgId">报销Id</param>
        public void CloseBill(System.Guid pgId)
        {
            SetMark_IsClosed(pgId, true);
            dbContext.SubmitChanges();
        }
    }
}
