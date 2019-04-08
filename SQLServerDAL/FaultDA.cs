using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiyi.JD.SQLServerDAL
{
    public class FaultDA : IDisposable
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

        ~FaultDA()
        {
            this.Dispose();
        }

        #region 故障数统计
        /// <summary>
        /// 获取故障总数
        /// </summary>
        /// <returns></returns>
        public int GetFaultSum()
        {
            return dbContext.Fault.Count();
        }



        #endregion

        /// <summary>
        /// 创建新故障
        /// </summary>
        /// <returns></returns>
        public Tiyi.JD.SQLServerDAL.Fault NewFault(Tiyi.JD.SQLServerDAL.Fault fault)
        {
            if (fault != null)
            {
                if (!ExistFault(fault.FaultText, fault.BigClass))
                {
                    fault.FaultId = Guid.NewGuid();
                    fault.CreateDate = DateTime.Now;
                    dbContext.Fault.InsertOnSubmit(fault);
                    dbContext.SubmitChanges();
                }
            }
            return fault;
        }

        /// <summary>
        /// 获取全部故障列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<Tiyi.JD.SQLServerDAL.Fault> GetFault()
        {
            var query = from c in dbContext.Fault
                        orderby c.BigClass
                        select c;
            return query.AsQueryable<Tiyi.JD.SQLServerDAL.Fault>();
        }

        /// <summary>
        /// 获取指定Id的故障
        /// </summary>
        /// <param name="faultId">故障Id</param>
        /// <returns></returns>
        public Tiyi.JD.SQLServerDAL.Fault GetFaultById(Guid faultId)
        {
            var query = from c in dbContext.Fault
                        where c.FaultId == faultId
                        select c;
            return query.FirstOrDefault<Tiyi.JD.SQLServerDAL.Fault>();
        }

        /// <summary>
        /// 获取指定故障名称获取故障实例数据
        /// </summary>
        /// <param name="faultText">故障名称</param>
        /// <returns></returns>
        public Tiyi.JD.SQLServerDAL.Fault GetFaultByName(string faultText)
        {
            var query = from c in dbContext.Fault
                        where c.FaultText == faultText
                        select c;
            return query.FirstOrDefault<Tiyi.JD.SQLServerDAL.Fault>();
        }

        /// <summary>
        /// 删除故障
        /// </summary>
        /// <param name="faultId">故障Id</param>
        public void DeleteFault(Guid faultId)
        {
            var query = from s in dbContext.Fault
                        where s.FaultId == faultId
                        select s;
            foreach (var para in query)
            {
                dbContext.Fault.DeleteOnSubmit(para);
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
        /// 更新故障信息
        /// </summary>
        /// <param name="fault">故障</param>
        public void UpdateFault(Tiyi.JD.SQLServerDAL.Fault fault)
        {
            dbContext.SubmitChanges();
        }

        /// <summary>
        /// 根据故障名称判别数据库中是否已存在故障
        /// </summary>
        /// <param name="faultText"></param>
        /// <returns></returns>
        public bool ExistFault(string faultText, string bigClass)
        {
            bool exists = false;
            var query = from u in dbContext.Fault
                        where u.FaultText == faultText && u.BigClass == bigClass
                        select u;
            if (query.Count() > 0)
            {
                exists = true;
            }
            return exists;
        }


    }
}
