using flowers_web.Common;
using flowers_web.Model;
using flowers_web.Model.Entitys;
using flowers_web.Service;
using flowers_web.Service.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flowers_web.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserServices _userServices;
        public ICustomerJWRService _customerJWRService;

        public UserController(IUserServices userServices, ICustomerJWRService customerJWRService) {
            _userServices = userServices;
            _customerJWRService = customerJWRService;
        }

        [HttpPost]
        public ApiResult Register(RegisterReq req) {
            ApiResult apiResult = new ApiResult() { IsSuccess = false };
            var curCode = MemoryHelper.GetMemory(req.ValidateKey);
            if (string.IsNullOrEmpty(req.UserName) || string.IsNullOrEmpty(req.Password) || string.IsNullOrEmpty(req.NickName) || string.IsNullOrEmpty(req.ValidateCode) || string.IsNullOrEmpty(req.ValidateKey))
            {
                apiResult.Msg = "参数不能为空";
            }
            else if (curCode == null)
            {
                apiResult.Msg = "验证码不存在，请刷新验证码";
            }
            else if (curCode.ToString() != req.ValidateCode)
            {
                apiResult.Msg = "验证码错误，请重新输入或刷新重试!";
            }
            else {
                string msg = string.Empty;
                var res = _userServices.RegisterUser(req, ref msg);
                if (!string.IsNullOrEmpty(msg))
                {
                    apiResult.Msg = msg;
                }
                else { 
                    apiResult.IsSuccess = true;
                    apiResult.Data = _customerJWRService.GetToken(res);
                }
            }
            return apiResult;
        }

        [HttpPost]
        public ApiResult Login(UserReq req)
        {
            ApiResult apiResult = new ApiResult() { IsSuccess = false };
            var curCode = MemoryHelper.GetMemory(req.ValidateKey);
            if (string.IsNullOrEmpty(req.UserName) || string.IsNullOrEmpty(req.Password) || string.IsNullOrEmpty(req.ValidateCode) || string.IsNullOrEmpty(req.ValidateKey))
            {
                apiResult.Msg = "参数不能为空";
            }
            else if (curCode == null)
            {
                apiResult.Msg = "验证码不存在，请刷新验证码";
            }
            else if (curCode.ToString() != req.ValidateCode)
            {
                apiResult.Msg = "验证码错误，请重新输入或刷新重试!";
            }
            else
            {
                var user = _userServices.GetUser(req);
                if (string.IsNullOrEmpty(user.UserName))
                {
                    apiResult.Msg = "账号不存在，用户名或密码错误!";
                }
                else
                {
                    apiResult.IsSuccess = true;
                    apiResult.Data = _customerJWRService.GetToken(user);
                }
            }
            return apiResult;
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetValidateCodeImage(string t) {
            var validateCodeString = Tools.CreateValidateString();
            MemoryHelper.SetMemory(t, validateCodeString, 5);
            byte[] buffer = Tools.CreateValidateCodeBuffer(validateCodeString);
            return File(buffer, @"image/jpeg");
        }
    }
}
