using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowers_web.Model
{
    public class ApiResult
    {
        public bool IsSuccess { get; set; }
        public Object Data { get; set; }
        public String Msg { get; set; }

    }
}
