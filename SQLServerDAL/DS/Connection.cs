using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Tiyi.JD.SQLServerDAL
{
    public class Connection
    {

        public static string GetConnectionString()
        {
            string conString = string.Empty;
            if (ConfigurationManager.ConnectionStrings["JD_SQL_ConnString"] != null)
            {
                conString = ConfigurationManager.ConnectionStrings["JD_SQL_ConnString"].ConnectionString;
            }
            else
            {
                throw new Exception("config 文件中找不到名称为 JD_SQL_ConnString 的数据库连接字符串");
            }
            return conString;
        }
    }


}
