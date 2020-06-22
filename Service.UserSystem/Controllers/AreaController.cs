using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthentValitor.AuthentModel;
using AuthentValitor.AuthHelper;
using Dto.IService.ResidentialAreaSystem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SystemFilter.PublicFilter;
using ViewModel.IViewModelFactory.InhabitantSystem;
using ViewModel.ResidentialAreaSystem.MiddleViewModel;
using ViewModel.ResidentialAreaSystem.ReponseViewModel;
using ViewModel.ResidentialAreaSystem.RequestViewModel;
using ViewModel.UserSystem.RequestViewModel;

namespace ResidentialAreaSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IResidentialAreaService _residentialAreaService;
        private readonly ILogger _ILogger;
        private readonly IAreaFactory _areaFactory;
        public AreaController(IResidentialAreaService  residentialAreaService, ILogger logger, IAreaFactory areaFactory)
        {
            _residentialAreaService = residentialAreaService;
            _ILogger = logger;
            _areaFactory = areaFactory;
        }

        /// <summary>
        /// 添加小区
        /// </summary>
        /// <param name="opinionInfoAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        [Authorize]
        public ActionResult<AreaAddResponseViewModel> Manage_OpinionInfo_Add(AreaAddViewModel opinionInfoAddViewModel)
        {
            int Area_add_Count;
            opinionInfoAddViewModel.AddTime = System.DateTime.Now;
            Area_add_Count = _residentialAreaService.addArea(opinionInfoAddViewModel);
            var opinionInfoAddResModel = _areaFactory.GetAreaAddResponseViewModel();
            if (Area_add_Count > 0)
            {
                opinionInfoAddResModel.baseViewModel.IsSuccess = true;
                opinionInfoAddResModel.AddCount = Area_add_Count;
                opinionInfoAddResModel.baseViewModel.Message = "添加成功";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添小区信息成功");
                return Ok(opinionInfoAddResModel);
            }
            else
            {
                opinionInfoAddResModel.baseViewModel.IsSuccess = false;
                opinionInfoAddResModel.AddCount = 0;
                opinionInfoAddResModel.baseViewModel.Message = "添加失败";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增添小区信息失败");
                return BadRequest(opinionInfoAddResModel);
            }
        }
        /// <summary>
        ///  查询小区信息
        /// </summary>
        /// <param name="areaSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<AreaSearchResModel> Manage_OpinionInfo_Search(AreaSearchViewModel areaSearchViewModel)
        {
            var SearchResult = _residentialAreaService.Area_Search(areaSearchViewModel);
            int total = _residentialAreaService.Area_SearchCount(areaSearchViewModel);
            var Actionresult = _areaFactory.GetAreaSearchResponseViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.TotalCount = total;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }
        ////根据Id删除小区信息
        //[HttpPost]
        //public ActionResult<AreaSearchResModel> Manage_OpinionInfo_DeleteById(AreaSearchViewModel areaSearchViewModel)
        //{

        //    List<AreaSearchMiddle> SearchResult = _residentialAreaService.Area_Search(areaSearchViewModel);

        //    _residentialAreaService.Area_Update();


        //    var Actionresult = _areaFactory.GetAreaSearchResponseViewModel();
        //    Actionresult.baseViewModel.IsSuccess = true;
        //    Actionresult.Data = SearchResult;
        //    Actionresult.baseViewModel.Message = "查询信息成功";
        //    Actionresult.baseViewModel.ResponseCode = 200;
        //    _ILogger.Information("查询信息成功");

        //    return Ok(Actionresult);

        //}
      
        /// <summary>
        /// 更改小区信息
        /// </summary>
        /// <param name="areaUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<AreaUpdateResViewModel> Manage_OpinionInfo_Update(AreaUpdateViewModel areaUpdateViewModel)
        {
            int Area_Update_Count;
            Area_Update_Count = _residentialAreaService.Area_Update(areaUpdateViewModel);
            var opinionInfoUpdateResModel = _areaFactory.GetAreaUpdateResponseViewModel();
            if (Area_Update_Count > 0)
            {
                opinionInfoUpdateResModel.baseViewModel.IsSuccess = true;
                opinionInfoUpdateResModel.AddCount = Area_Update_Count;
                opinionInfoUpdateResModel.baseViewModel.Message = "更改成功";
                opinionInfoUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("更改小区信息成功");
                return Ok(opinionInfoUpdateResModel);
            }
            else
            {
                opinionInfoUpdateResModel.baseViewModel.IsSuccess = false;
                opinionInfoUpdateResModel.AddCount = 0;
                opinionInfoUpdateResModel.baseViewModel.Message = "更改失败";
                opinionInfoUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("更改小区信息失败");
                return BadRequest(opinionInfoUpdateResModel);
            }
        }

    }
}