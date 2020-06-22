using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.InhabitantSystem;
using Microsoft.AspNetCore.Authorization;
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
    public class HouseInfoController : ControllerBase
    {
        private readonly IHouseInfoService _houseInfoService;
        private readonly ILogger _ILogger;
        private readonly IInhabitantFactory _inhabitantFactory;
        public HouseInfoController(IHouseInfoService houseInfoService, ILogger logger, IInhabitantFactory inhabitantFactory)
        {
            _houseInfoService = houseInfoService;
            _ILogger = logger;
            _inhabitantFactory = inhabitantFactory;
        }


        /// <summary>
        /// 添加房子
        /// </summary>
        /// <param name="houseInfoAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<HouseInfoAddResViewModel> Manage_OpinionInfo_Add(HouseInfoAddViewModel houseInfoAddViewModel)
        {
            int houseInfo_add_Count;
            //查询人员是否已存在

            //添加人员信息
            houseInfo_add_Count = _houseInfoService.AddHouseInfo(houseInfoAddViewModel);
            var opinionInfoAddResModel = _inhabitantFactory.GetHouseInfoAddResViewModel();
            if (houseInfo_add_Count > 0)
            {
                opinionInfoAddResModel.baseViewModel.IsSuccess = true;
                opinionInfoAddResModel.AddCount = houseInfo_add_Count;
                opinionInfoAddResModel.baseViewModel.Message = "添加成功";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添房子信息成功");
                return Ok(opinionInfoAddResModel);
            }
            else
            {
                opinionInfoAddResModel.baseViewModel.IsSuccess = false;
                opinionInfoAddResModel.AddCount = 0;
                opinionInfoAddResModel.baseViewModel.Message = "添加失败";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增添房子信息失败");
                return BadRequest(opinionInfoAddResModel);
            }



        }
        /// <summary>
        /// 查询房子信息
        /// </summary>
        /// <param name="houseInfoSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<HouseInfoSearchResViewModel> Manage_OpinionInfo_Search(HouseInfoSearchViewModel houseInfoSearchViewModel)
        {
            var SearchResult = _houseInfoService.HouseInfo_Search(houseInfoSearchViewModel);
            var Actionresult = _inhabitantFactory.GetHouseInfoSearchResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }
        /// <summary>
        /// 更新房子
        /// </summary>
        /// <param name="houseInfoUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult<HouseInfoUpdateResViewModel> Manage_OpinionInfo_Update(HouseInfoUpdateViewModel houseInfoUpdateViewModel)
        {
            int HouseInfo_Update_Count;
            HouseInfo_Update_Count = _houseInfoService.HouseInfo_Update(houseInfoUpdateViewModel);
            var opinionInfoUpdateResModel = _inhabitantFactory.GetInhabitantUpdateResViewModel();
            if (HouseInfo_Update_Count > 0)
            {
                opinionInfoUpdateResModel.baseViewModel.IsSuccess = true;
                opinionInfoUpdateResModel.AddCount = HouseInfo_Update_Count;
                opinionInfoUpdateResModel.baseViewModel.Message = "更改成功";
                opinionInfoUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("更改房子信息成功");
                return Ok(opinionInfoUpdateResModel);
            }
            else
            {
                opinionInfoUpdateResModel.baseViewModel.IsSuccess = false;
                opinionInfoUpdateResModel.AddCount = 0;
                opinionInfoUpdateResModel.baseViewModel.Message = "更改失败";
                opinionInfoUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("更改房子信息失败");
                return BadRequest(opinionInfoUpdateResModel);
            }
        }








    }
}