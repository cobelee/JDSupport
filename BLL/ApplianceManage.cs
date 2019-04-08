using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiyi.JD.SQLServerDAL;
namespace Tiyi.JD.BLL
{
    public class ApplianceManage
    {
        Tiyi.JD.SQLServerDAL.ApplianceDA appDA = new SQLServerDAL.ApplianceDA();

        /// <summary>
        /// 释放由本类占用的所有资源
        /// </summary>
        public void Dispose()
        {
            appDA.Dispose();
        }


        /// <summary>
        /// 对对象的更改提交至数据，使其生效
        /// </summary>
        public void SubmitChanges()
        {
            appDA.SubmitChanges();
        }

        /// <summary>
        /// 获取设备总数
        /// </summary>
        /// <returns></returns>
        public int GetCount_Appliance()
        {
            return appDA.GetCount_Appliance();
        }

        /// <summary>
        /// 创建新的设备。
        /// </summary>
        /// <param name="newBxBill">设备</param>
        /// <returns></returns>
        public Appliance CreateAppliance(Appliance newAppliance)
        {
            return appDA.CreateAppliance(newAppliance);
        }

        /// <summary>
        /// 创建新的设备
        /// <para>不立即提交数据库</para>
        /// </summary>
        /// <param name="newAppliance"></param>
        public void CreateApplianceNotSubmit(Appliance newAppliance)
        {
            appDA.CreateApplianceNotSubmit(newAppliance);
        }


        /// <summary>
        /// 获取在用设备列表。
        /// </summary>
        /// <returns></returns>
        public IQueryable<Appliance> GetAppliance_IsUsing()
        {
            return appDA.GetAppliance_IsUsing();
        }


        /// <summary>
        /// 获取指定appId的设备
        /// </summary>
        /// <param name="appId">设备ID</param>
        /// <returns></returns>
        public Appliance GetAppliance(Guid appId)
        {
            return appDA.GetAppliance(appId);
        }

        /// <summary>
        /// 获取指定productSN的设备
        /// </summary>
        /// <param name="productSN">设备管理号</param>
        /// <returns></returns>
        public Appliance GetAppliance(string productSN)
        {
            return appDA.GetAppliance(productSN);
        }

        /// <summary>
        /// 获取所有的设备所属公司名称列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<String> GetCorpNameList()
        {
            return appDA.GetCorpNameList();
        }

        /// <summary>
        /// 获取指定产品大类的设备所属公司名称列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<String> GetCorpNameList(string bigClass)
        {
            return appDA.GetCorpNameList(bigClass);
        }


        /// <summary>
        /// 修改设备信息
        /// </summary>
        /// <param name="newAppliance">设备。</param>
        public void UpdateAppliance(Appliance newAppliance)
        {
            appDA.UpdateAppliance(newAppliance);
        }



        /// <summary>
        /// 是否存在指定Id 设备
        /// </summary>
        /// <param name="appId">设备ID</param>
        /// <returns></returns>
        public bool ExistAppliance(Guid appId)
        {
            return appDA.ExistAppliance(appId);
        }

        /// <summary>
        /// 判断是否可能是重复设备。
        /// </summary>
        /// <param name="productSN">产品序号</param>
        /// <returns></returns>
        public bool IsRepetitiveAppliance(string productSN)
        {
            return appDA.IsRepetitiveAppliance(productSN);
        }

        /// <summary>
        /// 删除指定设备记录。
        /// </summary>
        /// <param name="productSN">设备编号 bxId .</param>
        public void DeleteAppliance(string productSN)
        {
            appDA.DeleteAppliance(productSN);
        }

        /// <summary>
        /// 删除指定设备记录。
        /// By AppId.
        /// </summary>
        /// <param name="appId">设备系统Id.</param>
        public void DeleteAppliance(Guid appId)
        {
            appDA.DeleteAppliance(appId);
        }

        /// <summary>
        /// 回收投资
        /// </summary>
        /// <param name="appId">设备IdId.</param>
        /// <param name="scrapDate">实际收回收益.</param>
        public void ScrapAppliance(Guid appId, DateTime? scrapDate)
        {
            appDA.ScrapAppliance(appId, scrapDate);
        }

    }
}
