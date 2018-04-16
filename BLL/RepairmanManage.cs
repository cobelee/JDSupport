using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiyi.JD.SQLServerDAL;

namespace Tiyi.JD.BLL
{
    public class RepairmanManage
    {
        Tiyi.JD.SQLServerDAL.RepairmanDA da = new SQLServerDAL.RepairmanDA();

        /// <summary>
        /// 释放由本类占用的所有资源
        /// </summary>
        public void Dispose()
        {
            da.Dispose();
        }


        #region 用户数统计
        /// <summary>
        /// 获取用户总数
        /// </summary>
        /// <returns></returns>
        public int GetRepairmanSum()
        {
            return da.GetRepairmanSum();
        }



        #endregion

        public Tiyi.JD.SQLServerDAL.Repairman NewRepairman(Tiyi.JD.SQLServerDAL.Repairman user)
        {
            return da.NewRepairman(user);
        }

        /// <summary>
        /// 获取全部修理工列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<Tiyi.JD.SQLServerDAL.Repairman> GetRepairman()
        {
            return da.GetRepairman();
        }

        /// <summary>
        /// 获取指定Id的修理工
        /// </summary>
        /// <param name="wxgId">修理工Id</param>
        /// <returns></returns>
        public Tiyi.JD.SQLServerDAL.Repairman GetRepairmanById(Guid wxgId)
        {
            return da.GetRepairmanById(wxgId);
        }

        /// <summary>
        /// 删除人员
        /// </summary>
        /// <param name="wxgId">维修工Id</param>
        public void DeleteRepairman(Guid wxgId)
        {
            da.DeleteRepairman(wxgId);
        }

        public void UpdateRepairman(Tiyi.JD.SQLServerDAL.Repairman user)
        {
            da.UpdateRepairman(user);
        }

        public bool ExistUser(string jobNumber)
        {
            return da.ExistUser(jobNumber);
        }

    }
}
