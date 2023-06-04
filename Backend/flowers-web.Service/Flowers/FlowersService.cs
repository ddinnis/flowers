
using AutoMapper;
using flowers_web.Common;
using flowers_web.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace flowers_web.Service
{
    public class FlowersService : IFlowersService
    {
        private readonly IMapper _mapper;
        public FlowersService(IMapper mapper) {
            _mapper = mapper;
        }
        public List<FlowersRes> GetFlowers(FlowersReq req)
        {
            // whereif 语法，当前面句子为true时，后面Expression才生效
           var res =  DbContext.db.Queryable<Flower>().WhereIF(req.Id > 0,x => x.Id == req.Id).WhereIF(req.Type > 0, x => x.Type == req.Type).ToArray();

            return _mapper.Map<List<FlowersRes>>(res);
        }
    }
}
