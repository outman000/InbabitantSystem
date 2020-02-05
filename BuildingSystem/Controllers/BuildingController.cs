using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.IService.BuildingSystem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.IViewModelFactory.IBuildingSystem;
using Serilog;
using ViewModel.BuildingSystem.ReponseViewModel;
using ViewModel.BuildingSystem.RequestViewModel;
using SystemFilter.PublicFilter;
using Dto.IService.InhabitantSystem;

namespace Service.BuildingSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;
        private readonly IHouseInfoService _houseInfoService;
        private readonly ILogger _ILogger;
        private readonly IBuildingFactory _buildingFactory;
        public BuildingController(IBuildingService buildingService, ILogger logger, IBuildingFactory buildingFactory, IHouseInfoService houseInfoService)
        {
            _buildingService = buildingService;
            _ILogger = logger;
            _buildingFactory = buildingFactory;
            _houseInfoService = houseInfoService;
        }
        /// <summary>
        /// 添加楼宇信息
        /// </summary>
        /// <param name="buildingAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public ActionResult<BuildingAddResViewModel> Manage_OpinionInfo_Add(BuildingAddViewModel buildingAddViewModel)
        {
            int Building_add_Count;
            buildingAddViewModel.AddTime = System.DateTime.Now;

            Building_add_Count = _buildingService.AddBuilding(buildingAddViewModel);
            var opinionInfoAddResModel = _buildingFactory.GetBuildingAddResViewModel();
            if (Building_add_Count > 0)
            {
                opinionInfoAddResModel.baseViewModel.IsSuccess = true;
                opinionInfoAddResModel.AddCount = Building_add_Count;
                opinionInfoAddResModel.baseViewModel.Message = "添加成功";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添楼宇信息成功");
                return Ok(opinionInfoAddResModel);
            }
            else
            {
                opinionInfoAddResModel.baseViewModel.IsSuccess = false;
                opinionInfoAddResModel.AddCount = 0;
                opinionInfoAddResModel.baseViewModel.Message = "添加失败";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增添楼宇信息失败");
                return BadRequest(opinionInfoAddResModel);
            }
        }

        /// <summary>
        /// 查询楼宇信息
        /// </summary>
        /// <param name="buildingSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<BuildingSearchResViewModel> Manage_OpinionInfo_Search(BuildingSearchViewModel buildingSearchViewModel)
        {
            var SearchResult = _buildingService.Building_Search(buildingSearchViewModel);
            int total = _buildingService.Building_SearchCount(buildingSearchViewModel);
            int buildingNoCount = _buildingService.Building_SearchBuildingNoCount(buildingSearchViewModel);
            int unitNoCount = _buildingService.Building_SearchUnitNoCount(buildingSearchViewModel);
            int houseNoCount = _houseInfoService.HouseCountSearch(buildingSearchViewModel);

            var Actionresult = _buildingFactory.GetBuildingSearchResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.TotalCount = total;
            Actionresult.BuildingNoCount = buildingNoCount;
            Actionresult.UnitNoCount = unitNoCount;
            Actionresult.HouseNoCount = houseNoCount;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }

        /// <summary>
        /// 更新楼宇信息
        /// </summary>
        /// <param name="buildingUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<BuildingUpdateResViewModel> Manage_OpinionInfo_Update(BuildingUpdateViewModel buildingUpdateViewModel)
        {
            int Building_Update_Count;
            Building_Update_Count = _buildingService.Building_Update(buildingUpdateViewModel);
            var opinionInfoUpdateResModel = _buildingFactory.GetBuildingUpdateResViewModel();
            if (Building_Update_Count > 0)
            {
                opinionInfoUpdateResModel.baseViewModel.IsSuccess = true;
                opinionInfoUpdateResModel.AddCount = Building_Update_Count;
                opinionInfoUpdateResModel.baseViewModel.Message = "更改成功";
                opinionInfoUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("更改楼宇信息成功");
                return Ok(opinionInfoUpdateResModel);
            }
            else
            {
                opinionInfoUpdateResModel.baseViewModel.IsSuccess = false;
                opinionInfoUpdateResModel.AddCount = 0;
                opinionInfoUpdateResModel.baseViewModel.Message = "更改失败";
                opinionInfoUpdateResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("更改楼宇信息失败");
                return BadRequest(opinionInfoUpdateResModel);
            }
        }






    }
}