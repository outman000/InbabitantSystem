using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Dto.IService.InhabitantSystem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.InhabitantSystem.RequestViewModel;
using ViewModel.InhabitantSystem.ResponseViewModel;
using ViewModel.IViewModelFactory.InhabitantSystem;

namespace Service.InhabitantSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly ILogger _ILogger;
        private readonly IInhabitantFactory _inhabitantFactory;
        public IdentityController(IIdentityService identityService, ILogger logger, IInhabitantFactory inhabitantFactory)
        {
            _identityService = identityService;
            _ILogger = logger;
            _inhabitantFactory = inhabitantFactory;
        }

        /// <summary>
        /// 添加身份信息
        /// </summary>
        /// <param name="identityAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<IdentityAddResViewModel> Manage_OpinionIdentity_Add(IdentityAddViewModel identityAddViewModel)
        {
            int Identity_add_Count;

            Identity_add_Count = _identityService.AddIdentity(identityAddViewModel);
            var opinionIdentityAddResModel = _inhabitantFactory.GetIdentityAddResViewModel();
            if (Identity_add_Count > 0)
            {
                opinionIdentityAddResModel.baseViewModel.IsSuccess = true;
                opinionIdentityAddResModel.AddCount = Identity_add_Count;
                opinionIdentityAddResModel.baseViewModel.Message = "添加成功";
                opinionIdentityAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添居民信息成功");
                return Ok(opinionIdentityAddResModel);
            }
            else
            {
                opinionIdentityAddResModel.baseViewModel.IsSuccess = false;
                opinionIdentityAddResModel.AddCount = 0;
                opinionIdentityAddResModel.baseViewModel.Message = "添加失败";
                opinionIdentityAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增添居民信息失败");
                return BadRequest(opinionIdentityAddResModel);
            }



        }


        /// <summary>
        /// 查询身份
        /// </summary>
        /// <param name="identitySearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<IdentitySearchResViewModel> Manage_OpinionInfo_Search(IdentitySearchViewModel identitySearchViewModel)
        {
            var SearchResult = _identityService.Identity_Search(identitySearchViewModel);
            int total=_identityService.Identity_SearchCount(identitySearchViewModel);
            var Actionresult = _inhabitantFactory.GetIdentitySearchResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.TotalCount = total;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }


        /// <summary>
        /// 更新身份
        /// </summary>
        /// <param name="identityUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<IdentityUpdateResViewModel> Manage_OpinionInfo_Update(IdentityUpdateViewModel identityUpdateViewModel)
        {
            int Identity_Update_Count;
            Identity_Update_Count = _identityService.Identity_Update(identityUpdateViewModel);
            var opinionIdentityUpdateResModel = _inhabitantFactory.GetInhabitantUpdateResViewModel();
            if (Identity_Update_Count > 0)
            {
                opinionIdentityUpdateResModel.baseViewModel.IsSuccess = true;
                opinionIdentityUpdateResModel.AddCount = Identity_Update_Count;
                opinionIdentityUpdateResModel.baseViewModel.Message = "更改成功";
                opinionIdentityUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("更改身份成功");
                return Ok(opinionIdentityUpdateResModel);
            }
            else
            {
                opinionIdentityUpdateResModel.baseViewModel.IsSuccess = false;
                opinionIdentityUpdateResModel.AddCount = 0;
                opinionIdentityUpdateResModel.baseViewModel.Message = "更改失败";
                opinionIdentityUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("更改身份失败");
                return BadRequest(opinionIdentityUpdateResModel);
            }
        }
    }
}