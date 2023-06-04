using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowers_web.Service
{
    public class UserReq
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ValidateKey { get; set; }
        public string ValidateCode { get; set; }

    }
}
