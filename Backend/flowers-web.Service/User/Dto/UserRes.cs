using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowers_web.Service { 
    public class UserRes
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public DateTime? CreateTime { get; set; }
        public int UserType { get; set; }
    }
}
