using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace flowers_web.Model.Entitys
{
    public class Orders
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }

        [SugarColumn(IsNullable = false)]
        public string OrderNumber { get; set; }

        [SugarColumn(IsNullable = true)]
        public decimal TotalPrice { get; set; }

        [SugarColumn(IsNullable = false)]
        public DateTime OrderDate { get; set; }

        [SugarColumn(IsNullable = false)]
        public long FlowerId { get; set; }
        [SugarColumn(IsNullable = false)]
        public long UserId { get; set; }
    }
}
