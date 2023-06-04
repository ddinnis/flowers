using flowers_web.Model;
using flowers_web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flowers_web.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService) { 
            _orderService = orderService;
        }

        [HttpPost]
        [Authorize]
        public ApiResult CreateOrder(OrderReq req) {
            ApiResult apiResult = new ApiResult() { IsSuccess=false};
            if (req.FlowerId == 0)
            {
                apiResult.Msg = "参数不可以为空!";
            }
            else {
                string msg = string.Empty;
                // long userId = Convert.ToInt32(HttpContext.User.Claims.ToList()[0].Value);
                bool res = _orderService.CreateOrder(req, 123456, ref msg);
                if (!string.IsNullOrEmpty(msg))
                {
                    apiResult.Msg = msg;
                }
                else {
                    apiResult.IsSuccess = true;
                    apiResult.Data = res;
                }
            }
            return apiResult;
        }
    }
}
