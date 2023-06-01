using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowers_web.Common
{
    public class DbContext
    {
        public static SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
        {
            ConnectionString = "Data Source=LAPTOP-1H2QHK1H\\SQLEXPRESS;Initial Catalog=User;Persist Security Info=True;User ID=sa;Password=123456",
            DbType = DbType.SqlServer,
            IsAutoCloseConnection = true // 不为true则需手动close
        });

        public static void InitDataBase() { 
            // 初始化数据库，如不存在则创建数据库
            db.DbMaintenance.CreateDatabase();
        }
    }
}
