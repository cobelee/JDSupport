using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiyi.JD.SQLServerDAL;

namespace Tiyi.JD.BLL
{
    public class BaoxiuManage
    {
        Tiyi.JD.SQLServerDAL.BaoxiuBillDA da = new BaoxiuBillDA();

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
        /// 获取指定状态的报修单数量
        /// </summary>
        /// <param name="isAccept">客服是否受理</param>
        /// <param name="isCompleted">报修单是否处理完毕</param>
        /// <returns></returns>
        public int GetCount(bool isAccept, bool isCompleted)
        {
            return da.GetCount(isAccept, isCompleted);
        }

        /// <summary>
        /// 创建新的报修单。
        /// </summary>
        /// <param name="newBxBill">报修单</param>
        /// <returns></returns>
        public BaoxiuBill CreateBaoxiuBill(BaoxiuBill newBaoxiuBill)
        {
            return da.CreateBaoxiuBill(newBaoxiuBill);
        }

        /// <summary>
        /// 该方法供批量创建新报修单时使用
        /// <para>不立即提交数据库</para>
        /// </summary>
        /// <param name="newBaoxiuBill"></param>
        public void CreateBaoxiuBillNotSubmit(BaoxiuBill newBaoxiuBill)
        {
            da.CreateBaoxiuBillNotSubmit(newBaoxiuBill);
        }

        /// <summary>
        /// 获取指定设备的所有报修单。
        /// </summary>
        /// <param name = "appId" > 设备Id </ param >
        /// < returns ></ returns >
        public IQueryable<BaoxiuBill> GetBaoxiuBill_ForOneApp(Guid appId)
        {
            return da.GetBaoxiuBill_ForOneApp(appId);
        }

        /// <summary>
        /// 获取所有未完成报修单列表。
        /// </summary>
        /// <returns></returns>
        public IQueryable<BaoxiuBill> GetBaoxiuBill_IsNotCompleted()
        {
            return da.GetBaoxiuBill_IsNotCompleted();
        }


        /// <summary>
        /// 获取指定appId的报修单
        /// </summary>
        /// <param name="bxId">报修单ID</param>
        /// <returns></returns>
        public BaoxiuBill GetBaoxiuBill(Guid bxId)
        {
            return da.GetBaoxiuBill(bxId);
        }

        /// <summary>
        /// 根据报修单号获取对应的派工单。
        /// </summary>
        /// <param name="bxId">报修单Id</param>
        /// <returns></returns>
        public PaigongBill GetPgBill_ByBxId(Guid bxId)
        {
            return da.GetPgBill_ByBxId(bxId);
        }


        /// <summary>
        /// 修改报修单信息
        /// </summary>
        /// <param name="newBaoxiuBill">报修单。</param>
        public void UpdateBaoxiuBill(BaoxiuBill newBaoxiuBill)
        {
            da.UpdateBaoxiuBill(newBaoxiuBill);
        }



        /// <summary>
        /// 是否存在指定Id 报修单
        /// </summary>
        /// <param name="bxId">报修单ID</param>
        /// <returns></returns>
        public bool ExistBaoxiuBill(Guid bxId)
        {
            return da.ExistBaoxiuBill(bxId);
        }

        /// <summary>
        /// 判断是否可能是重复报修单。
        /// </summary>
        /// <param name="productSN">产品序号</param>
        /// <returns></returns>
        public bool IsRepetitiveBaoxiuBill(string productSN)
        {
            return da.IsRepetitiveBaoxiuBill(productSN);
        }

        /// <summary>
        /// 删除指定报修单记录。
        /// </summary>
        /// <param name="appId">报修单编号 bxId .</param>
        public void DeleteBaoxiuBill(string productSN)
        {
            da.DeleteBaoxiuBill(productSN);
        }


        /// <summary>
        /// 设置报销申请单的 IsClosed 标记
        /// </summary>
        /// <param name="bxId">报修单Id</param>
        /// <param name="isCompleted">是否维修完成</param>
        private void SetMark_IsCompleted(Guid bxId, bool isCompleted)
        {
            da.SetMark_IsCompleted(bxId, isCompleted);
        }


        /// <summary>
        /// 判断指定报修单是否已经安排派工维修
        /// </summary>
        /// <param name="bxId">报修单Id</param>
        /// <returns></returns>
        public bool IsPaidang(Guid bxId)
        {
            return da.IsPaidang(bxId);
        }
    }
}
