using flowers_web.Service.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowers_web.Service
{
    public interface IOrderService
    {
        bool CreateOrder(OrderReq req, long userId, ref string msg);
    }
}
