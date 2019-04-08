using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiyi.JD.SQLServerDAL
{
    public class CorporationDA : IDisposable
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

        ~CorporationDA()
        {
            this.Dispose();
        }

        #region 公司数统计
        /// <summary>
        /// 获取公司总数
        /// </summary>
        /// <returns></returns>
        public int GetCorporationSum()
        {
            return dbContext.Corporation.Count();
        }



        #endregion

        /// <summary>
        /// 创建新公司（此公司为安装设备的所在单位）
        /// </summary>
        /// <returns></returns>
        public Tiyi.JD.SQLServerDAL.Corporation NewCorporation(Tiyi.JD.SQLServerDAL.Corporation corp)
        {
            if (corp != null)
            {
                if (!ExistCorp(corp.CorpName))
                {
                    corp.CorpId = Guid.NewGuid();
                    corp.CreateDate = DateTime.Now;
                    dbContext.Corporation.InsertOnSubmit(corp);
                    dbContext.SubmitChanges();
                }
            }
            return corp;
        }

        /// <summary>
        /// 获取全部公司列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<Tiyi.JD.SQLServerDAL.Corporation> GetCorporation()
        {
            var query = from c in dbContext.Corporation
                        select c;
            return query.AsQueryable<Tiyi.JD.SQLServerDAL.Corporation>();
        }

        /// <summary>
        /// 获取指定Id的公司
        /// </summary>
        /// <param name="corpId">公司Id</param>
        /// <returns></returns>
        public Tiyi.JD.SQLServerDAL.Corporation GetCorporationById(Guid corpId)
        {
            var query = from c in dbContext.Corporation
                        where c.CorpId == corpId
                        select c;
            return query.FirstOrDefault<Tiyi.JD.SQLServerDAL.Corporation>();
        }

        /// <summary>
        /// 获取指定公司名称获取公司实例数据
        /// </summary>
        /// <param name="corpName">公司名称</param>
        /// <returns></returns>
        public Tiyi.JD.SQLServerDAL.Corporation GetCorporationByName(string corpName)
        {
            var query = from c in dbContext.Corporation
                        where c.CorpName == corpName
                        select c;
            return query.FirstOrDefault<Tiyi.JD.SQLServerDAL.Corporation>();
        }

        /// <summary>
        /// 删除公司
        /// </summary>
        /// <param name="corpId">公司Id</param>
        public void DeleteCorporation(Guid corpId)
        {
            var query = from s in dbContext.Corporation
                        where s.CorpId == corpId
                        select s;
            foreach (var para in query)
            {
                dbContext.Corporation.DeleteOnSubmit(para);
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

        public void UpdateCorporation(Tiyi.JD.SQLServerDAL.Corporation corp)
        {
            dbContext.SubmitChanges();
        }

        /// <summary>
        /// 根据公司名称判别数据库中是否已存在公司
        /// </summary>
        /// <param name="corpName"></param>
        /// <returns></returns>
        public bool ExistCorp(string corpName)
        {
            bool exists = false;
            var query = from u in dbContext.Corporation
                        where u.CorpName == corpName
                        select u;
            if (query.Count() > 0)
            {
                exists = true;
            }
            return exists;
        }


    }
}
