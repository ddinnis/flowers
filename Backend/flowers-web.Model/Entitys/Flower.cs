using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowers_web.Model.Entitys
{
    public class Flower
    {
        [SugarColumn(IsPrimaryKey = true,IsIdentity = true)]
        public long Id { get; set; }

        [SugarColumn(IsNullable = false)]
        public string Title { get; set; }

        [SugarColumn(IsNullable = true)]
        public int Type { get; set; }

        [SugarColumn(IsNullable = false)]
        public string Image { get; set; }
        [SugarColumn(IsNullable = false)]
        public string BigImage { get; set; }

        [SugarColumn(IsNullable = false)]
        public string Description { get; set; }
        [SugarColumn(IsNullable = false)]
        public decimal Price { get; set; }
        [SugarColumn(IsNullable = false)]
        public string Language { get; set; }
        [SugarColumn(IsNullable = false)]
        public string Packing { get; set; }
        [SugarColumn(IsNullable = false)]
        public string DeliveryRemarks { get; set; }
    }
}
