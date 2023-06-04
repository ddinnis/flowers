using AutoMapper;
using flowers_web.Model.Entitys;

namespace flowers_web.Service.Config
{
    public class AutoMapperConfigs:Profile
    {
        // 配置映射关系
        public AutoMapperConfigs()
        {
            CreateMap<Flower, FlowersRes>();
            CreateMap<Users, UserRes>();
            CreateMap<RegisterReq, Users>();
        }
    }
}
