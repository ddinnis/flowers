using AutoMapper;
using flowers_web.Common;
using flowers_web.Model.Entitys;
using flowers_web.Model.Enum;
using flowers_web.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowers_web.Service.User
{
    public class UserService : IUserServices
    {
        private readonly IMapper _mapper;
        public UserService(IMapper mapper) {
            _mapper = mapper;
        }
        public UserRes RegisterUser(RegisterReq req, ref string msg)
        {
            var user = DbContext.db.Queryable<Users>().First(p => p.UserName == req.UserName);
            if (user != null)
            {
                msg = "账号已存在";
                return _mapper.Map<UserRes>(user);
            }
            else {
                try
                {
                    Users users = _mapper.Map<Users>(req);
                    users.CreateTime = DateTime.Now;
                    users.UserType = (int)EnumUserType.normalUser;
                    // 返回一个整数值，表示对数据库所影响的行数。如果返回值大于0，则说明执行插入操作成功，返回值为0，没有成功插入任何数据，小于0，则说明执行插入操作时发生了错误。
                    bool res = DbContext.db.Insertable(users).ExecuteCommand()>0;

                    if(res){
                        user = DbContext.db.Queryable<Users>().First(p => p.UserName == req.UserName && p.Password == req.Password);
                        return _mapper.Map<UserRes>(user);
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
            }
            return new UserRes();
        }

        public UserRes GetUser(UserReq req) {
            var user = DbContext.db.Queryable<Users>().First(p => p.UserName == req.UserName && p.Password == req.Password);

            if (user != null) {
                return _mapper.Map<UserRes>(user);
            }

            return new UserRes();
        }
    }
}
