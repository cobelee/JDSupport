using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiyi.JD.SQLServerDAL
{
    public class RepairmanDA : IDisposable
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

        ~RepairmanDA()
        {
            this.Dispose();
        }

        #region 用户数统计
        /// <summary>
        /// 获取用户总数
        /// </summary>
        /// <returns></returns>
        public int GetRepairmanSum()
        {
            return dbContext.Repairman.Count();
        }

        /// <summary>
        /// 获取已认证并登记进微信企业号中的人员数。
        /// </summary>
        /// <returns></returns>
        //public int GetIsQYUser_Sum()
        //{
        //    return dbContext.Repairman.Where(o => o.IsQYUser == true).Count();
        //}

        #endregion

        public Tiyi.JD.SQLServerDAL.Repairman NewRepairman(Tiyi.JD.SQLServerDAL.Repairman user)
        {
            if (user != null)
            {
                if (!ExistUser(user.JobNumber))
                {
                    user.WxgId = Guid.NewGuid();
                    dbContext.Repairman.InsertOnSubmit(user);
                    dbContext.SubmitChanges();
                }
            }
            return user;
        }

        /// <summary>
        /// 获取全部修理工列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<Tiyi.JD.SQLServerDAL.Repairman> GetRepairman()
        {
            var query = from c in dbContext.Repairman
                        select c;
            return query.AsQueryable<Tiyi.JD.SQLServerDAL.Repairman>();
        }

        /// <summary>
        /// 获取指定Id的修理工
        /// </summary>
        /// <param name="WxgId">修理工Id</param>
        /// <returns></returns>
        public Tiyi.JD.SQLServerDAL.Repairman GetRepairmanById(Guid WxgId)
        {
            var query = from c in dbContext.Repairman
                        where c.WxgId == WxgId
                        select c;
            return query.FirstOrDefault<Tiyi.JD.SQLServerDAL.Repairman>();
        }

        /// <summary>
        /// 获取指定工号的修理工
        /// </summary>
        /// <param name="jobNumber">修理工工号</param>
        /// <returns></returns>
        public Tiyi.JD.SQLServerDAL.Repairman GetRepairmanByJobNumber(string jobNumber)
        {
            var query = from c in dbContext.Repairman
                        where c.JobNumber == jobNumber
                        select c;
            return query.FirstOrDefault<Tiyi.JD.SQLServerDAL.Repairman>();
        }

        /// <summary>
        /// 删除人员
        /// </summary>
        /// <param name="WxgId">维修工Id</param>
        public void DeleteRepairman(Guid WxgId)
        {
            var query = from s in dbContext.Repairman
                        where s.WxgId == WxgId
                        select s;
            foreach (var para in query)
            {
                dbContext.Repairman.DeleteOnSubmit(para);
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

        public void UpdateRepairman(Tiyi.JD.SQLServerDAL.Repairman userinfo)
        {
            dbContext.SubmitChanges();
        }

        public bool ExistUser(string jobNumber)
        {
            bool exists = false;
            var query = from u in dbContext.Repairman
                        where u.JobNumber == jobNumber
                        select u;
            if (query.Count() > 0)
            {
                exists = true;
            }
            return exists;
        }


    }
}
