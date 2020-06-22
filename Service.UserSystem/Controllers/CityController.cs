using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.MaintainSystem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ViewModel.IViewModelFactory.MaintainSystem;
using ViewModel.MaintainSystem.ResponseViewModel;

namespace Service.MaintainSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly ILogger _ILogger;
        private readonly IMaintainFactory _maintainFactory;
        public CityController(ICityService cityService, ILogger logger, IMaintainFactory maintainFactory)
        {
            _cityService = cityService;
            _ILogger = logger;
            _maintainFactory = maintainFactory;
        }

        /// <summary>
        ///  查询所有省份
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<CitySearchResViewModel> Manage_OpinionInfo_Search()
        {
            var SearchResult = _cityService.GetAllProvince();
            var Actionresult = _maintainFactory.GetCitySearchResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }
        /// <summary>
        ///  根据FormId查询子城市
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<CitySearchResViewModel> Manage_OpinionInfo_SearchByFormId(Guid FromId)
        {
            var SearchResult = _cityService.GetCityChildren(FromId);
            var Actionresult = _maintainFactory.GetCitySearchResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }









    }
}