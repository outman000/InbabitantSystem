using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.MaintainSystem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ViewModel.IViewModelFactory.MaintainSystem;
using ViewModel.MaintainSystem.ResponseViewModel;

namespace Service.MaintainSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PoliticalController : ControllerBase
    {
        private readonly IPoliticalService _politicalService;
        private readonly ILogger _ILogger;
        private readonly IMaintainFactory _maintainFactory;
        public PoliticalController(IPoliticalService politicalService, ILogger logger, IMaintainFactory maintainFactory)
        {
            _politicalService = politicalService;
            _ILogger = logger;
            _maintainFactory = maintainFactory;
        }

        /// <summary>
        ///  查询所有政治面貌
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<PoliticalSearchResViewModel> Manage_OpinionInfo_Search()
        {
            var SearchResult = _politicalService.GetAll();
            var Actionresult = _maintainFactory.GetPoliticalSearchResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }

    }
}