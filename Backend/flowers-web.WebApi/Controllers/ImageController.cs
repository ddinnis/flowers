using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flowers_web.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpGet]
        public List<ImageModel> GetImages() {
            List<ImageModel> list = new List<ImageModel>() {
                new ImageModel() {ImageUrl="https://imgapi.cn/api.php?zd=zsy&fl=fengjing&gs=images", JumpUrl="http://localhost:8081/"},
                new ImageModel() {ImageUrl="https://imgapi.cn/api.php?zd=pc&fl=fengjing&gs=images", JumpUrl="http://localhost:8081/"},
                new ImageModel() {ImageUrl="https://imgapi.cn/api.php?zd=zsy&fl=suiji&gs=images", JumpUrl="http://localhost:8081/"}
            };
            return list;
        }
    }
}
