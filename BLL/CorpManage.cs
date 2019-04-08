using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiyi.JD.SQLServerDAL;

namespace Tiyi.JD.BLL
{
    public class CorpManage
    {
        Tiyi.JD.SQLServerDAL.CorporationDA da = new CorporationDA();

        /// <summary>
        /// 释放由本类占用的所有资源
        /// </summary>
        public void Dispose()
        {
            da.Dispose();
        }

        #region 公司数统计
        /// <summary>
        /// 获取公司总数
        /// </summary>
        /// <returns></returns>
        public int GetCorporationSum()
        {
            return da.GetCorporationSum();
        }



        #endregion

        /// <summary>
        /// 创建新公司（此公司为安装设备的所在单位）
        /// </summary>
        /// <returns></returns>
        public Tiyi.JD.SQLServerDAL.Corporation NewCorporation(Tiyi.JD.SQLServerDAL.Corporation corp)
        {
            return da.NewCorporation(corp);
        }

        /// <summary>
        /// 获取全部公司列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<Tiyi.JD.SQLServerDAL.Corporation> GetCorporation()
        {
            return da.GetCorporation();
        }

        /// <summary>
        /// 获取指定Id的公司
        /// </summary>
        /// <param name="corpId">公司Id</param>
        /// <returns></returns>
        public Tiyi.JD.SQLServerDAL.Corporation GetCorporationById(Guid corpId)
        {
            return da.GetCorporationById(corpId);
        }

        /// <summary>
        /// 获取指定公司名称获取公司实例数据
        /// </summary>
        /// <param name="corpName">公司名称</param>
        /// <returns></returns>
        public Tiyi.JD.SQLServerDAL.Corporation GetCorporationByName(string corpName)
        {
            return da.GetCorporationByName(corpName);
        }

        /// <summary>
        /// 删除公司
        /// </summary>
        /// <param name="corpId">公司Id</param>
        public void DeleteCorporation(Guid corpId)
        {
            da.DeleteCorporation(corpId);
        }

        public void UpdateCorporation(Tiyi.JD.SQLServerDAL.Corporation corp)
        {
            da.UpdateCorporation(corp);
        }

        /// <summary>
        /// 根据公司名称判别数据库中是否已存在公司
        /// </summary>
        /// <param name="corpName"></param>
        /// <returns></returns>
        public bool ExistCorp(string corpName)
        {
            return da.ExistCorp(corpName);
        }
    }
}
