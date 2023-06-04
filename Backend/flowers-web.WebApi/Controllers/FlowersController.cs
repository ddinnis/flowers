using flowers_web.Model;
using flowers_web.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flowers_web.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FlowersController : ControllerBase
    {
        public IFlowersService _flowerService;
        public FlowersController(IFlowersService flowerService) {
            _flowerService = flowerService;
        }

        [HttpPost]
        public ApiResult GetFlowers(FlowersReq req)
        {
            ApiResult apiReault = new ApiResult() { IsSuccess = true};
            apiReault.Data = _flowerService.GetFlowers(req);
            return apiReault;
        }
    }
}
