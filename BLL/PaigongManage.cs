using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiyi.JD.SQLServerDAL;

namespace Tiyi.JD.BLL
{
    public class PaigongManage
    {
        Tiyi.JD.SQLServerDAL.PaigongBillDA da = new PaigongBillDA();

        /// <summary>
        /// 释放由本类占用的所有资源
        /// </summary>
        public void Dispose()
        {
            da.Dispose();
        }


        /// <summary>
        /// 对对象的更改提交至数据，使其生效
        /// </summary>
        public void SubmitChanges()
        {
            da.SubmitChanges();
        }

        /// <summary>
        /// 创建新的派工单。
        /// </summary>
        /// <param name="newBxBill">派工单</param>
        /// <returns></returns>
        public PaigongBill CreatePaigongBill(PaigongBill newPaigongBill)
        {
            return da.CreatePaigongBill(newPaigongBill);
        }

        /// <summary>
        /// 该方法供批量创建新派工单时使用
        /// <para>不立即提交数据库</para>
        /// </summary>
        /// <param name="newPaigongBill"></param>
        public void CreatePaigongBillNotSubmit(PaigongBill newPaigongBill)
        {
            da.CreatePaigongBillNotSubmit(newPaigongBill);
        }


        /// <summary>
        /// 获取所有未完成派工单列表。
        /// </summary>
        /// <returns></returns>
        public IQueryable<PaigongBill> GetPaigongBill_IsNotClosed()
        {
            return da.GetPaigongBill_IsNotClosed();
        }


        /// <summary>
        /// 获取指定appId的派工单
        /// </summary>
        /// <param name="pgId">派工单ID</param>
        /// <returns></returns>
        public PaigongBill GetPaigongBill(Guid pgId)
        {
            return da.GetPaigongBill(pgId);
        }


        /// <summary>
        /// 修改派工单信息
        /// </summary>
        /// <param name="newPaigongBill">派工单。</param>
        public void UpdatePaigongBill(PaigongBill newPaigongBill)
        {
            da.UpdatePaigongBill(newPaigongBill);
        }



        /// <summary>
        /// 是否存在指定Id 派工单
        /// </summary>
        /// <param name="pgId">派工单ID</param>
        /// <returns></returns>
        public bool ExistPaigongBill(Guid pgId)
        {
            return da.ExistPaigongBill(pgId);
        }

        /// <summary>
        /// 删除指定派工单记录。
        /// </summary>
        /// <param name="appId">派工单编号 pgId .</param>
        public void DeletePaigongBill(string productSN)
        {
            da.DeletePaigongBill(productSN);
        }


        /// <summary>
        /// 设置报销申请单的 IsClosed 标记
        /// </summary>
        /// <param name="pgId">派工单Id</param>
        /// <param name="isClosed">是否维修完成</param>
        public void SetMark_IsClosed(Guid pgId, bool isClosed)
        {
            da.SetMark_IsClosed(pgId, isClosed);
        }

        /// <summary>
        /// 关闭报销业务。
        /// </summary>
        /// <param name="pgId">报销Id</param>
        public void CloseBill(System.Guid pgId)
        {
            da.CloseBill(pgId);
        }
    }
}
