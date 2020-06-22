using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.InhabitantSystem.ResponseViewModel;
using Serilog;
using Dto.IService.InhabitantSystem;
using ViewModel.IViewModelFactory.InhabitantSystem;
using Dto.Service.ResidentialAreaSystem;
using Dto.IService.ResidentialAreaSystem;
using Microsoft.AspNetCore.Authorization;

namespace Service.InhabitantSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;
        private readonly IResidentialAreaService _residentialAreaService;
        private readonly ILogger _ILogger;
        private readonly IInhabitantFactory _inhabitantFactory;
        public StatisticsController(IStatisticsService statisticsService, ILogger logger, IInhabitantFactory inhabitantFactory, IResidentialAreaService residentialAreaService)
        {
            _statisticsService = statisticsService;
            _ILogger = logger;
            _inhabitantFactory = inhabitantFactory;
            _residentialAreaService = residentialAreaService;
        }


        /// <summary>
        ///  统计每个小区人数
        /// </summary>
        
        /// <returns ></returns >
        [HttpPost]
        [Authorize]
        public ActionResult<AreaPopulationStatisticsResViewModel> Manage_OpinionInfo_AreaPopulationStatistics()
        {
            var AreaName = _residentialAreaService.GetAllArea();
            var SearchResult = _statisticsService.GetAreaPopulation(AreaName);
            var Actionresult = _inhabitantFactory.GetAreaPopulationStatisticsResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }

        /// <summary>
        ///  统计各年龄段人数
        /// </summary>
        
        /// <returns ></returns >
        [HttpPost]
        [Authorize]
        public ActionResult<AgeStatisticsResViewModel> Manage_OpinionInfo_AgeStatistics()
        {

            var SearchResult = _statisticsService.GetAgeCount();
            var Actionresult = _inhabitantFactory.GetAgeStatisticsResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }

        /// <summary>
        ///  统计男女人数
        /// </summary>
        
        /// <returns ></returns >
        [HttpPost]
        [Authorize]
        public ActionResult<GenderStatisticsResViewModel> Manage_OpinionInfo_GenderStatistics()
        {

            var SearchResult = _statisticsService.GetGenderCount();
            var Actionresult = _inhabitantFactory.GetGenderStatisticsResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }



    }
}