using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowers_web.Service
{
    public interface IFlowersService
    {
        List<FlowersRes> GetFlowers(FlowersReq req);
    }
}
