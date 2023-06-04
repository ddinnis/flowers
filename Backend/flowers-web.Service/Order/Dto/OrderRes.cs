using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowers_web.Service
{
    public class OrderRes
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public decimal  Price { get; set; }
        public DateTime OrderDate { get; set; }
        public string FlowerTtile { get; set; }
        public long UserId { get; set;}
    }
}
