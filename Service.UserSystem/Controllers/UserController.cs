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
        public ActionResult<UserSearchResViewModel> Manage_OpinionInfo_Search(UserSearchViewModel userSearchViewModel)
        {
            var SearchResult = _userService.User_Search(userSearchViewModel);
            var Actionresult = _userFactory.GetUserSearchResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }





    }
}