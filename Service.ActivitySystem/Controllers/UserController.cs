using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.UserSystem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ViewModel.IViewModelFactory.UserSystem;
using ViewModel.UserSystem.RequestViewModel;
using ViewModel.UserSystem.ResponseViewModel;
using AuthentValitor.AuthentModel;
using AuthentValitor.AuthHelper;
using Microsoft.AspNetCore.Authorization;

namespace Service.UserSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger _ILogger;
        private readonly IUserFactory _userFactory;
        public UserController(IUserService userService, ILogger logger, IUserFactory userFactory)
        {
            _userService = userService;
            _ILogger = logger;
            _userFactory = userFactory;
        }


        /// <summary>
        ///  查询用户
        /// </summary>
        /// <param name="userSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<UserSearchResViewModel> Manage_OpinionInfo_Search(UserSearchViewModel userSearchViewModel)
        {
            var SearchResult = _userService.User_Search(userSearchViewModel);
            var Actionresult = _userFactory.GetUserSearchResViewModel();
            if (SearchResult == 1)
            {
                Actionresult.baseViewModel.IsSuccess = true;
                Actionresult.Data = SearchResult;
                Actionresult.baseViewModel.Message = "查询信息成功";
                Actionresult.baseViewModel.ResponseCode = 200;
                _ILogger.Information("查询信息成功");
            }
            else
            {
                Actionresult.baseViewModel.IsSuccess = false;
                Actionresult.Data = SearchResult;
                Actionresult.baseViewModel.Message = "查询信息失败";
                Actionresult.baseViewModel.ResponseCode = 200;
                _ILogger.Information("查询信息失败");
            }

            return Ok(Actionresult);

        }

        /// <summary>
        /// 这个也需要认证，只不过登录即可，不一定是Admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult Get1231232(string token)
        {
            TokenModelJwt aa = JwtHelper.SerializeJwt(token);
            var Actionresult = _userFactory.GetUserSearchResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = 1;
            Actionresult.baseViewModel.Message = "解析信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("解析信息成功");
            return Ok(Actionresult);
        }

        /// <summary>
        /// 登录接口：随便输入字符，获取token，然后添加 Authoritarian
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetJWTToken(UserSearchViewModel userSearchViewModel)
        {
            string jwtStr = string.Empty;
            bool suc = false;
            //这里就是用户登陆以后，通过数据库去调取数据，分配权限的操作
            //这里直接写死了
            //if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pass))
            //{
            //    return new JsonResult(new
            //    {
            //        Status = false,
            //        message = "用户名或密码不能为空"
            //    });
            //}
          
            var SearchResult = _userService.User_Search(userSearchViewModel);
            var Actionresult = _userFactory.GetUserSearchResViewModel();
            if (SearchResult == 1)
            {
                Actionresult.baseViewModel.IsSuccess = true;
                Actionresult.Data = SearchResult;
                Actionresult.baseViewModel.Message = "查询信息成功";
                Actionresult.baseViewModel.ResponseCode = 200;
                _ILogger.Information("查询信息成功");
                TokenModelJwt tokenModel = new TokenModelJwt();
                tokenModel.Uid = 2;
                tokenModel.Role = "Admin";
                jwtStr = JwtHelper.IssueJwt(tokenModel);
                Actionresult.token = jwtStr;
                return Ok(Actionresult);

            }
            else
            {
                Actionresult.baseViewModel.IsSuccess = false;
                Actionresult.Data = SearchResult;
                Actionresult.baseViewModel.Message = "查询信息失败";
                Actionresult.baseViewModel.ResponseCode = 200;
                _ILogger.Information("查询信息失败");
                return Ok(Actionresult);
            }
       

           
        }
    }
}