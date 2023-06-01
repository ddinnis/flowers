using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flowers_web.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FlowersController : ControllerBase
    {
        [HttpGet]
        public List<Flower> GetFlowers()
        {
            List<Flower> flowers = new List<Flower>() {
            new Flower() { Id = 0, Title = "韩式系列", Type = 1, Image = "https://imgapi.cn/api.php?zd=mobile&fl=fengjing&gs=images", BigImage = "https://imgapi.cn/api.php?zd=mobile&fl=fengjing&gs=images", Description = "粉玫境11枝、白色详桔梗5技、大叶尤加利10枝", Price = 200, Language = "娇糕的粉色斯支部政地与清新的白色详精梗，经过花艺师之手试予了奢的息义", Packing = "粉/玫粉色家鞋巢6网张、白色0PT雾而纸3涨、W花粉色罗纹领全丝带2米”", DeliveryRemarks = "江浙沪包邮，偏远地区除外，小城市请提前一天预定" } 
            };
            return flowers;
        }
    }
}
