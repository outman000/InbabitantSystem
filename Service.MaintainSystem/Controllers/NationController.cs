using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.MaintainSystem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.MaintainSystem.ResponseViewModel;
using Serilog;
using ViewModel.IViewModelFactory.MaintainSystem;

namespace Service.MaintainSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NationController : ControllerBase
    {

        private readonly INationService _nationService;
        private readonly ILogger _ILogger;
        private readonly IMaintainFactory _maintainFactory;
        public NationController(INationService nationService, ILogger logger, IMaintainFactory maintainFactory)
        {
            _nationService = nationService;
            _ILogger = logger;
            _maintainFactory = maintainFactory;
        }

        /// <summary>
        ///  查询所有民族
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<NationSearchResViewModel> Manage_OpinionInfo_Search()
        {
            var SearchResult = _nationService.GetAll();
            var Actionresult = _maintainFactory.GetNationSearchResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }
    }
}