using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowers_web.Model.Entitys
{
    public class Users
    {
        [SugarColumn(IsPrimaryKey =true,IsIdentity =true) ]
        public long Id { get; set; }

        [SugarColumn(IsNullable =false)]
        public string UserName { get; set; }
        [SugarColumn(IsNullable = false)]
        public string NickName { get; set; }
        [SugarColumn(IsNullable = false)]
        public string Password { get; set; }
        [SugarColumn(IsNullable = false)]
        public DateTime? CreateTime { get; set; }
        [SugarColumn(IsNullable = false)]
        public int UserType { get; set; }
    }
}
