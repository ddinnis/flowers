using flowers_web.Model.Entitys;
using SqlSugar;
using System.Reflection;

namespace flowers_web.Common
{
    public class DbContext
    {
        public static SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
        {
            ConnectionString = "Data Source=LAPTOP-1H2QHK1H\\SQLEXPRESS;Initial Catalog=Flowers;Persist Security Info=True;User ID=sa;Password=123456",
            DbType = DbType.SqlServer,
            IsAutoCloseConnection = true // 不为true则需手动close
        });

        public static void InitDataBase() { 
            // 初始化数据库，如不存在则创建数据库
            db.DbMaintenance.CreateDatabase();
            string nameSpace = "flowers_web.Model.Entitys";
            Type[] ass = Assembly.LoadFrom("bin/Debug/net6.0/flowers-web.Model.dll").GetTypes().Where(
                p => p.Namespace == nameSpace).ToArray();
            db.CodeFirst.SetStringDefaultLength(200).InitTables(ass);

            // 写入测试数据
            List<Flower> flowers = new List<Flower>() {
                new Flower() { Id = 0, Title = "韩式系列", Type = 1, Image = "https://imgapi.cn/api.php?zd=mobile&fl=suiji&gs=images", BigImage = "https://imgapi.cn/api.php?zd=mobile&fl=fengjing&gs=images", Description = "粉玫境11枝、白色详桔梗5技、大叶尤加利10枝", Price = 200, Language = "娇糕的粉色斯支部政地与清新的白色详精梗，经过花艺师之手试予了奢的息义", Packing = "粉/玫粉色家鞋巢6网张、白色0PT雾而纸3涨、W花粉色罗纹领全丝带2米”", DeliveryRemarks = "江浙沪包邮，偏远地区除外，小城市请提前一天预定" },
                new Flower() { Id = 1, Title = "美式系列", Type = 2, Image = "https://imgapi.cn/api.php?zd=mobile&fl=fengjing&gs=images", BigImage = "https://imgapi.cn/api.php?zd=mobile&fl=fengjing&gs=images", Description = "粉玫境11枝、白色详桔梗5技、大叶尤加利10枝", Price = 300, Language = "娇糕的粉色斯支部政地与清新的白色详精梗，经过花艺师之手试予了奢的息义", Packing = "粉/玫粉色家鞋巢6网张、白色0PT雾而纸3涨、W花粉色罗纹领全丝带2米”", DeliveryRemarks = "江浙沪包邮，偏远地区除外，小城市请提前一天预定" }
                ,
                new Flower() { Id = 2, Title = "日式系列", Type = 3, Image = "https://imgapi.cn/api.php?zd=mobile&fl=suiji&gs=images", BigImage = "https://imgapi.cn/api.php?zd=mobile&fl=fengjing&gs=images", Description = "粉玫境11枝、白色详桔梗5技、大叶尤加利10枝", Price = 400, Language = "娇糕的粉色斯支部政地与清新的白色详精梗，经过花艺师之手试予了奢的息义", Packing = "粉/玫粉色家鞋巢6网张、白色0PT雾而纸3涨、W花粉色罗纹领全丝带2米”", DeliveryRemarks = "江浙沪包邮，偏远地区除外，小城市请提前一天预定" }
                };

            db.Insertable(flowers).ExecuteCommand();
        }
        
    };
}
