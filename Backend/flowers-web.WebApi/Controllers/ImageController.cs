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
                new ImageModel() {ImageUrl="https://cdn.cdnjson.com/tvax3.sinaimg.cn//large/0072Vf1pgy1foxki3cf3xj31hc0u0wt7.jpg", JumpUrl="http://localhost:8081/"},
                new ImageModel() {ImageUrl="https://cdn.cdnjson.com/tvax3.sinaimg.cn//large/0072Vf1pgy1foxlo4q77mj31kw0w0kev.jpg", JumpUrl="http://localhost:8081/"},
                new ImageModel() {ImageUrl="https://cdn.cdnjson.com/tvax3.sinaimg.cn//large/0072Vf1pgy1foxlhey5i9j31kw0w0khl.jpg", JumpUrl="http://localhost:8081/"}
            };
            return list;
        }
    }
}
