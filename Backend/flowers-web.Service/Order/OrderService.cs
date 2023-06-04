using AutoMapper;
using flowers_web.Common;
using flowers_web.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowers_web.Service.Order
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;

        public OrderService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public bool CreateOrder(OrderReq req, long userId, ref string msg)
        {
            var flower = DbContext.db.Queryable<Flower>().First(p => p.Id == req.FlowerId);
            if (flower == null) {
                msg = "商品信息不存在!";
            }
            Orders orders = new Orders() {
                OrderDate = DateTime.Now,
                OrderNumber = DateTime.Now.ToString("yyyyMMddHHmmffff"),
                UserId = userId,
                FlowerId = req.FlowerId,
                TotalPrice = flower.Price
            };

            return DbContext.db.Insertable(orders).ExecuteCommand() > 0;
        }

    }
}
