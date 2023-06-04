using flowers_web.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowers_web.Service.User
{
    public interface IUserServices
    {
        UserRes RegisterUser(RegisterReq req, ref string msg);
        UserRes GetUser(UserReq req);
    }
}
