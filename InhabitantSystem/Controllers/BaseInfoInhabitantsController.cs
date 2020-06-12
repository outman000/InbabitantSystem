using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.InhabitantSystem;
using Dtol.Dtol;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ViewModel.InhabitantSystem.RequestViewModel;
using ViewModel.InhabitantSystem.ResponseViewModel;
using ViewModel.IViewModelFactory.InhabitantSystem;

namespace Service.InhabitantSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseInfoInhabitantsController : ControllerBase
    {
        private readonly IBaseInfoInhabitantsService _baseInfoInhabitantsService;
        private readonly ILogger _ILogger;
        private readonly IInhabitantFactory _inhabitantFactory;

        public BaseInfoInhabitantsController(IBaseInfoInhabitantsService baseInfoInhabitantsService, ILogger logger, IInhabitantFactory inhabitantFactory)
        {
            _baseInfoInhabitantsService = baseInfoInhabitantsService;
            _ILogger = logger;
            _inhabitantFactory = inhabitantFactory;
        }

        /// <summary>
        /// 通知页面 根据房屋信息，身份，人员信息 查询
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<BaseInfoInhabitantsResViewModel> Manage_OpinionInfo_Search(BaseInfoInhabitantViewModel baseInfoInhabitantViewModel)
        {
            var SearchResult = _baseInfoInhabitantsService.getResidentByAllInfo(baseInfoInhabitantViewModel);
            int Total = _baseInfoInhabitantsService.getResidentByAllInfoCount(baseInfoInhabitantViewModel);
            var Actionresult = _inhabitantFactory.GetBaseInfoInhabitantsResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.TotalCount = Total;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }


        /// <summary>
        /// 查询添加身份时 查询不是当前身份的居民信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<AddIdentitySearchResidentResViewModel> AddIdentity_OpinionInfo_Search(AddIdentitySearchResidentViewModel addIdentitySearchResidentViewModel)
        {
            var SearchResult = _baseInfoInhabitantsService.getAddIdentitySearchResident(addIdentitySearchResidentViewModel);
            int Total = _baseInfoInhabitantsService.getAddIdentitySearchResidentCount(addIdentitySearchResidentViewModel);
            var Actionresult = _inhabitantFactory.GetAddIdentitySearchResidentResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.TotalCount = Total;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }


        /// <summary>
        /// 查询身份时 查询当前身份的居民信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<IdentitySearchResidentResViewModel> Identity_OpinionInfo_Search(IdentitySearchResidentViewModel identitySearchResidentViewModel)
        {
            var SearchResult = _baseInfoInhabitantsService.getIdentitySearchResident(identitySearchResidentViewModel);
            int toatal = _baseInfoInhabitantsService.getIdentitySearchResidentCount(identitySearchResidentViewModel);
            var Actionresult = _inhabitantFactory.GetIdentitySearchResidentResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.TotalCount = toatal;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }






        /// <summary>
        /// 居民信息查询时 查询的居民信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ResidentInfoSearchResViewModel> residentInfoSearch_OpinionInfo_Search(ResidentInfoSearchViewModel residentInfoSearchViewModel)
        {
            var SearchResult = _baseInfoInhabitantsService.getResidentInfoSearchResident(residentInfoSearchViewModel);
            int total= _baseInfoInhabitantsService.getResidentInfoSearchResidentCount(residentInfoSearchViewModel);
            var Actionresult = _inhabitantFactory.GetResidentInfoSearchResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.TotalCount = total;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }

        /// <summary>
        /// 根据具体房子信息查询
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ByHouseInfoSearchResidentResViewModel> ByHouseInfoSearchResident_OpinionInfo_Search(ByHouseInfoSearchResidentViewModel byHouseInfoSearchResidentViewModel)
        {
            var SearchResult = _baseInfoInhabitantsService.getByHouseInfoSearchResident(byHouseInfoSearchResidentViewModel);

            var Actionresult = _inhabitantFactory.GetByHouseInfoSearchResidentResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }



     


    }
}