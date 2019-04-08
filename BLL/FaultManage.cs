using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiyi.JD.SQLServerDAL;

namespace Tiyi.JD.BLL
{
    public class FaultManage
    {
        Tiyi.JD.SQLServerDAL.FaultDA da = new FaultDA();


        /// <summary>
        /// 释放由本类占用的所有资源
        /// </summary>
        public void Dispose()
        {
            da.Dispose();
        }


        #region 故障数统计
        /// <summary>
        /// 获取故障总数
        /// </summary>
        /// <returns></returns>
        public int GetFaultSum()
        {
            return da.GetFaultSum();
        }



        #endregion

        /// <summary>
        /// 创建新故障
        /// </summary>
        /// <returns></returns>
        public Tiyi.JD.SQLServerDAL.Fault NewFault(Tiyi.JD.SQLServerDAL.Fault fault)
        {
            return da.NewFault(fault);
        }

        /// <summary>
        /// 获取全部故障列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<Tiyi.JD.SQLServerDAL.Fault> GetFault()
        {
            return da.GetFault();
        }

        /// <summary>
        /// 获取指定Id的故障
        /// </summary>
        /// <param name="faultId">故障Id</param>
        /// <returns></returns>
        public Tiyi.JD.SQLServerDAL.Fault GetFaultById(Guid faultId)
        {
            return da.GetFaultById(faultId);
        }

        /// <summary>
        /// 获取指定故障名称获取故障实例数据
        /// </summary>
        /// <param name="faultText">故障名称</param>
        /// <returns></returns>
        public Tiyi.JD.SQLServerDAL.Fault GetFaultByName(string faultText)
        {
            return da.GetFaultByName(faultText);
        }

        /// <summary>
        /// 删除故障
        /// </summary>
        /// <param name="faultId">故障Id</param>
        public void DeleteFault(Guid faultId)
        {
            da.DeleteFault(faultId);
        }

        /// <summary>
        /// 更新故障信息
        /// </summary>
        /// <param name="fault">故障</param>
        public void UpdateFault(Tiyi.JD.SQLServerDAL.Fault fault)
        {
            da.UpdateFault(fault);
        }

        /// <summary>
        /// 根据故障名称判别数据库中是否已存在故障
        /// </summary>
        /// <param name="faultText"></param>
        /// <returns></returns>
        public bool ExistFault(string faultText, string bigClass)
        {
            return da.ExistFault(faultText, bigClass);
        }


    }
}
