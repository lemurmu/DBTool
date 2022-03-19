
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalMonitor.DataAccess
{
    public class Common
    {
       
        public static string connectionString = ConfigurationManager.ConnectionStrings["db_signal_mysql"].ConnectionString;
      
        public static IFreeSql Fsql = new FreeSql.FreeSqlBuilder()
                 .UseConnectionString(FreeSql.DataType.MySql, connectionString)
                 .UseAutoSyncStructure(false) //自动同步实体结构到数据库
                 .Build(); //请务必定义成 Singleton 单例模式



    }
}
