using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiyi.JD.SQLServerDAL;

namespace Tiyi.JD.BLL
{
    /// <summary>
    /// 维保管理
    /// <para></para>
    /// </summary>
    public class WeibaoManage
    {
        Tiyi.JD.SQLServerDAL.WeibaoLogDA da = new SQLServerDAL.WeibaoLogDA();


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
        /// 创建新的维保记录。
        /// </summary>
        /// <param name="newBxBill">维保记录</param>
        /// <returns></returns>
        public WeibaoLog CreateWeibaoLog(WeibaoLog newWeibaoLog)
        {
            return da.CreateWeibaoLog(newWeibaoLog);
        }

        /// <summary>
        /// 该方法供批量创建新维保记录时使用
        /// <para>不立即提交数据库</para>
        /// </summary>
        /// <param name="newWeibaoLog"></param>
        public void CreateWeibaoLogNotSubmit(WeibaoLog newWeibaoLog)
        {
            da.CreateWeibaoLogNotSubmit(newWeibaoLog);
        }

        /// <summary>
        /// 获取指定appId的维保记录
        /// </summary>
        /// <param name="appId">设备ID</param>
        /// <returns></returns>
        public IQueryable<WeibaoLog> GetWeibaoLog(Guid appId)
        {
            return da.GetWeibaoLog(appId);
        }


        /// <summary>
        /// 获取指定appId的最近一次维保记录
        /// </summary>
        /// <param name="appId">设备ID</param>
        /// <returns></returns>
        public WeibaoLog GetLastWeibaoLog(Guid appId)
        {
            return da.GetLastWeibaoLog(appId);
        }




        /// <summary>
        /// 修改维保记录信息
        /// </summary>
        /// <param name="newWeibaoLog">维保记录。</param>
        public void UpdateWeibaoLog(WeibaoLog newWeibaoLog)
        {
            da.UpdateWeibaoLog(newWeibaoLog);
        }


        /// <summary>
        /// 删除指定维保记录记录。
        /// </summary>
        /// <param name="wbId">维保记录 wbId .</param>
        public void DeleteWeibaoLog(Guid wbId)
        {
            da.DeleteWeibaoLog(wbId);
        }
    }
}
