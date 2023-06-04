using flowers_web.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flowers_web.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        [HttpGet]
        public void InitDatabase() { 
            DbContext.InitDataBase();
        }
    }
}
