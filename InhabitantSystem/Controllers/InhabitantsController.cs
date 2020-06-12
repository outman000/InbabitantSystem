using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel.InhabitantSystem.RequestViewModel;
using Dto.IService.InhabitantSystem;
using ViewModel.IViewModelFactory.InhabitantSystem;
using ViewModel.InhabitantSystem.ResponseViewModel;
using ViewModel.InhabitantSystem.MiddleViewModel;

namespace InhabitantSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InhabitantsController : ControllerBase
    {
        private readonly IInhabitantService _inhabitantService;
        private readonly IHouseInfoRelationShipService _houseInfoRelationShipService;
        private readonly IResidentIdentityRelationShipService _residentIdentityRelationShipService;
        private readonly IPartyService _partyService;
        private readonly IHouseInfoService _houseInfoService;
        private readonly ILogger _ILogger;
        private readonly IInhabitantFactory _inhabitantFactory;
        public InhabitantsController(IInhabitantService inhabitantService, 
                                     ILogger logger, 
                                     IInhabitantFactory inhabitantFactory,
                                     IHouseInfoRelationShipService houseInfoRelationShipService,
                                     IResidentIdentityRelationShipService residentIdentityRelationShipService,
                                     IHouseInfoService houseInfoService,
                                     IPartyService partyService
                                     )
        {
            _inhabitantService = inhabitantService;
            _ILogger = logger;
            _inhabitantFactory = inhabitantFactory;
            _houseInfoRelationShipService = houseInfoRelationShipService;
            _residentIdentityRelationShipService = residentIdentityRelationShipService;
            _houseInfoService = houseInfoService;
            _partyService = partyService;
        }

        /// <summary>
        /// 添加居民和房子信息 And 居民和房子关系信息
        /// </summary>
        /// <param name="inhabitantAndHouseInfoAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<InhabitantAndHouseInfoAddResViewModel> ResidentAndHouseInfo_Manage_OpinionInfo_Add(InhabitantAndHouseInfoAddViewModel inhabitantAndHouseInfoAddViewModel)
        {
            inhabitantAndHouseInfoAddViewModel.inhabitantAndHouseInfoAddMiddles[0].HouseId= Guid.NewGuid();
            //添加房子信息
          var temp=  _houseInfoService.AddHouseInfoSingle(inhabitantAndHouseInfoAddViewModel.inhabitantAndHouseInfoAddMiddles[0]);
            InhabitantAndHouseInfoAddResViewModel inhabitantAndHouseInfoAddResViewModel = new InhabitantAndHouseInfoAddResViewModel();
            if (temp==0)
            {
                inhabitantAndHouseInfoAddResViewModel.baseViewModel.IsSuccess = false;
                inhabitantAndHouseInfoAddResViewModel.AddCount = 0;
                inhabitantAndHouseInfoAddResViewModel.baseViewModel.Message = "添加失败";
                inhabitantAndHouseInfoAddResViewModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("地址重复，添加失败");
                return Ok(inhabitantAndHouseInfoAddResViewModel);
            }
          

            var houseId = inhabitantAndHouseInfoAddViewModel.inhabitantAndHouseInfoAddMiddles[0].HouseId;

            int InhabitantAndHouseInfo_add_Count=0;

            var opinionInfoAddResModel = _inhabitantFactory.GetInhabitantAndHouseInfoAddResViewModel();
            foreach (InhabitantAndHouseInfoAddMiddle model in inhabitantAndHouseInfoAddViewModel.inhabitantAndHouseInfoAddMiddles)
            {
                //验证居民是否重复
                var checkInhabitant = _inhabitantService.Inhabitant_ByIdNo_Search(model.IdNumber);
                if (checkInhabitant !=null)
                {
                    model.HouseId = houseId;
                    model.RelationShipId = Guid.NewGuid();
                    //如果居民存在，把model的id 设置成查出的居民id
                    model.InhabitantId = checkInhabitant.Id;
                    //添加居民和房子关系
                    _houseInfoRelationShipService.AddHouseInfoRelationShipSingle(model);

                    InhabitantAndHouseInfo_add_Count++;

                }
                else
                {
                    model.HouseId = houseId;
                    model.RelationShipId = Guid.NewGuid();
                    model.InhabitantId = Guid.NewGuid();
                    //添加居民信息
                    _inhabitantService.AddInhabitantSingle(model);

                    //添加居民和房子关系
                    _houseInfoRelationShipService.AddHouseInfoRelationShipSingle(model);

                    InhabitantAndHouseInfo_add_Count++;

                    //添加党员信息
                    if (model.Politics == "中共党员")
                    {
                        PartyInfoAddViewModel partyInfoAddViewModel = new PartyInfoAddViewModel();
                        partyInfoAddViewModel.ResidentId = model.InhabitantId;
                        partyInfoAddViewModel.IdNumber = model.IdNumber;

                        int Party_add_Count = 0;
                        Party_add_Count = _partyService.AddPartyInfo(partyInfoAddViewModel);
                    }
                }
                
                

            }
            

            if (InhabitantAndHouseInfo_add_Count > 0)
            {
                opinionInfoAddResModel.baseViewModel.IsSuccess = true;
                opinionInfoAddResModel.AddCount = InhabitantAndHouseInfo_add_Count;
                opinionInfoAddResModel.baseViewModel.Message = "添加成功";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添信息成功");
                return Ok(opinionInfoAddResModel);
            }
            else
            {
                opinionInfoAddResModel.baseViewModel.IsSuccess = false;
                opinionInfoAddResModel.AddCount = 0;
                opinionInfoAddResModel.baseViewModel.Message = "添加失败";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增添信息失败");
                return BadRequest(opinionInfoAddResModel);
            }
        }


        /// <summary>
        /// 批量添加居民
        /// </summary>
        /// <param name="inhabitantAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<InhabitantAddResViewModel> Manage_OpinionInfo_Add(InhabitantAddViewModel inhabitantAddViewModel)
        {
            int Inhabitant_add_Count ;
            

            //添加人员信息
            Inhabitant_add_Count = _inhabitantService.AddInhabitant(inhabitantAddViewModel);
            var opinionInfoAddResModel = _inhabitantFactory.GetInhabitantAddResViewModel();
            if (Inhabitant_add_Count > 0)
            {
                opinionInfoAddResModel.baseViewModel.IsSuccess = true;
                opinionInfoAddResModel.AddCount = Inhabitant_add_Count;
                opinionInfoAddResModel.baseViewModel.Message = "添加成功";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添居民信息成功");
                return Ok(opinionInfoAddResModel);
            }
            else
            {
                opinionInfoAddResModel.baseViewModel.IsSuccess = false;
                opinionInfoAddResModel.AddCount = 0;
                opinionInfoAddResModel.baseViewModel.Message = "添加失败";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增添居民信息失败");
                return BadRequest(opinionInfoAddResModel);
            }
           
            

        }
        /// <summary>
        /// 查询居民信息
        /// </summary>
        /// <param name="inhabitantSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<InhabitantSearchResModel> Manage_OpinionInfo_Search(InhabitantSearchViewModel inhabitantSearchViewModel)
        {
            var SearchResult = _inhabitantService.Inhabitant_Search(inhabitantSearchViewModel);
            var Actionresult = _inhabitantFactory.GetInhabitantSearchResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }
        /// <summary>
        /// 批量更新居民
        /// </summary>
        /// <param name="inhabitantUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<InhabitantUpdateResViewModel> Manage_OpinionInfo_Update(InhabitantUpdateViewModel inhabitantUpdateViewModel)
        {
            int Inhabitant_Update_Count;
            Inhabitant_Update_Count = _inhabitantService.Inhabitant_Update(inhabitantUpdateViewModel);
            var opinionInfoUpdateResModel = _inhabitantFactory.GetInhabitantUpdateResViewModel();

             if(Inhabitant_Update_Count== 999999)
             {
                opinionInfoUpdateResModel.baseViewModel.IsSuccess = false;
                opinionInfoUpdateResModel.AddCount = 0;
                opinionInfoUpdateResModel.baseViewModel.Message = "更改失败";
                opinionInfoUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("家庭住址已存在，更改居民信息失败");
                return Ok(opinionInfoUpdateResModel);

             }
            if (Inhabitant_Update_Count > 0)
            {
                opinionInfoUpdateResModel.baseViewModel.IsSuccess = true;
                opinionInfoUpdateResModel.AddCount = Inhabitant_Update_Count;
                opinionInfoUpdateResModel.baseViewModel.Message = "更改成功";
                opinionInfoUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("更改居民信息成功");
                return Ok(opinionInfoUpdateResModel);
            }
            else
            {
                opinionInfoUpdateResModel.baseViewModel.IsSuccess = false;
                opinionInfoUpdateResModel.AddCount = 0;
                opinionInfoUpdateResModel.baseViewModel.Message = "更改失败";
                opinionInfoUpdateResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("更改居民信息失败");
                return BadRequest(opinionInfoUpdateResModel);
            }
        }


        /// <summary>
        /// 批量添加居民和房子关系表  信息
        /// </summary>
        /// <param name="houseInfoRelationShipAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<HouseInfoRelationShipAddResViewModel> HouseRelationShip_Manage_OpinionInfo_Add(HouseInfoRelationShipAddViewModel houseInfoRelationShipAddViewModel)
        {
            int HouseInfoRelationShip_add_Count;
            //查询人员是否已存在

            //添加人员信息
            HouseInfoRelationShip_add_Count = _houseInfoRelationShipService.AddHouseInfoRelationShip(houseInfoRelationShipAddViewModel);
            var opinionInfoAddResModel = _inhabitantFactory.GetHouseInfoRelationShipAddResViewModel();
            if (HouseInfoRelationShip_add_Count > 0)
            {
                opinionInfoAddResModel.baseViewModel.IsSuccess = true;
                opinionInfoAddResModel.AddCount = HouseInfoRelationShip_add_Count;
                opinionInfoAddResModel.baseViewModel.Message = "添加成功";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添居民和房子关系信息成功");
                return Ok(opinionInfoAddResModel);
            }
            else
            {
                opinionInfoAddResModel.baseViewModel.IsSuccess = false;
                opinionInfoAddResModel.AddCount = 0;
                opinionInfoAddResModel.baseViewModel.Message = "添加失败";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增添居民和房子关系信息失败");
                return BadRequest(opinionInfoAddResModel);
            }
        }
        /// <summary>
        /// 批量删除居民和房子关系表  信息
        /// </summary>
        /// <param name="houseInfoRelationShipDeleteViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<HouseInfoRelationShipDeleteResViewModel> HouseRelationShip_Manage_OpinionInfo_Delete(HouseInfoRelationShipDeleteViewModel houseInfoRelationShipDeleteViewModel)
        {
            int HouseInfoRelationShip_delete_Count;


            //添加人员信息
            HouseInfoRelationShip_delete_Count = _houseInfoRelationShipService.DeleteHouseInfoRelationShip(houseInfoRelationShipDeleteViewModel);
            var opinionInfoAddResModel = _inhabitantFactory.GetHouseInfoRelationShipDeleteResViewModel();
            if (HouseInfoRelationShip_delete_Count > 0)
            {
                opinionInfoAddResModel.baseViewModel.IsSuccess = true;
                opinionInfoAddResModel.AddCount = HouseInfoRelationShip_delete_Count;
                opinionInfoAddResModel.baseViewModel.Message = "删除成功";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("删除居民和房子关系信息成功");
                return Ok(opinionInfoAddResModel);
            }
            else
            {
                opinionInfoAddResModel.baseViewModel.IsSuccess = false;
                opinionInfoAddResModel.AddCount = 0;
                opinionInfoAddResModel.baseViewModel.Message = "删除失败";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("删除居民和房子关系信息失败");
                return BadRequest(opinionInfoAddResModel);
            }
        }


        /// <summary>
        /// 批量添加居民和身份关系表  信息
        /// </summary>
        /// <param name="residentIdentityRelationShipAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ResidentIdentityRelationShipAddResViewModel> IdentityRelationShip_Manage_OpinionInfo_Add(ResidentIdentityRelationShipAddViewModel residentIdentityRelationShipAddViewModel)
        {
            int ResidentIdentityRelationShip_add_Count;
            //查询人员是否已存在

            //添加人员信息
            ResidentIdentityRelationShip_add_Count = _residentIdentityRelationShipService.AddResidentIdentityRelationShip(residentIdentityRelationShipAddViewModel);
            var opinionInfoAddResModel = _inhabitantFactory.GetResidentIdentityRelationShipAddResViewModel();
            if (ResidentIdentityRelationShip_add_Count > 0)
            {
                opinionInfoAddResModel.baseViewModel.IsSuccess = true;
                opinionInfoAddResModel.AddCount = ResidentIdentityRelationShip_add_Count;
                opinionInfoAddResModel.baseViewModel.Message = "添加成功";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添  居民和身份  关系信息成功");
                return Ok(opinionInfoAddResModel);
            }
            else
            {
                opinionInfoAddResModel.baseViewModel.IsSuccess = false;
                opinionInfoAddResModel.AddCount = 0;
                opinionInfoAddResModel.baseViewModel.Message = "添加失败";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增添  居民和身份  关系信息失败");
                return BadRequest(opinionInfoAddResModel);
            }



        }


        /// <summary>
        /// 批量删除居民和身份关系表  信息
        /// </summary>
        /// <param name="residentIdentityRelationShipDeleteViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ResidentIdentityRelationShipDeleteResViewModel> IdentityRelationShip_Manage_OpinionInfo_Delete(ResidentIdentityRelationShipDeleteViewModel residentIdentityRelationShipDeleteViewModel)
        {
            int ResidentIdentityRelationShip_delete_Count;
            //查询人员是否已存在

            //添加人员信息
            ResidentIdentityRelationShip_delete_Count = _residentIdentityRelationShipService.DeleteResidentIdentityRelationShip(residentIdentityRelationShipDeleteViewModel);
            var opinionInfoAddResModel = _inhabitantFactory.GetResidentIdentityRelationShipDeleteResViewModel();
            if (ResidentIdentityRelationShip_delete_Count > 0)
            {
                opinionInfoAddResModel.baseViewModel.IsSuccess = true;
                opinionInfoAddResModel.AddCount = ResidentIdentityRelationShip_delete_Count;
                opinionInfoAddResModel.baseViewModel.Message = "删除成功";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 200;
                _ILogger.Information("删除  居民和身份  关系信息成功");
                return Ok(opinionInfoAddResModel);
            }
            else
            {
                opinionInfoAddResModel.baseViewModel.IsSuccess = false;
                opinionInfoAddResModel.AddCount = 0;
                opinionInfoAddResModel.baseViewModel.Message = "添加失败";
                opinionInfoAddResModel.baseViewModel.ResponseCode = 400;
                _ILogger.Information("删除  居民和身份  关系信息失败");
                return BadRequest(opinionInfoAddResModel);
            }



        }

        /// <summary>
        /// 查询党员的居民信息
        /// </summary>
        /// <param name="partyResidentSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<PartyResidentSearchResViewModel> ByHouseInfoSearchResident_OpinionInfo_Search(PartyResidentSearchViewModel partyResidentSearchViewModel)
        {
            var SearchResult = _inhabitantService.getPartResidentSearch(partyResidentSearchViewModel);
            int total = _inhabitantService.getPartResidentSearchCount(partyResidentSearchViewModel);
            var Actionresult = _inhabitantFactory.GetPartyResidentSearchResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.TotalCount = total;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }




        /// <summary>
        /// 根据id 查询党员的具体信息和该党员的基本信息
        /// </summary>
        /// <param name="partyResidentByIdSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<PartyResidentByIdSearchResViewModel> ByIDSearchResident_OpinionInfo_Search(PartyResidentByIdSearchViewModel partyResidentByIdSearchViewModel)
        {
            var SearchResult = _inhabitantService.getPartResidentByIdSearch(partyResidentByIdSearchViewModel);

            var Actionresult = _inhabitantFactory.GetPartyResidentByIdSearchResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }


        /// <summary>
        /// 添加党员信息
        /// </summary>
        /// <param name="partyInfoAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<PartyInfoAddResViewModel> Party_OpinionInfo_Add(PartyInfoAddViewModel partyInfoAddViewModel)
        {
            int Party_add_Count=0;
            Party_add_Count = _partyService.AddPartyInfo(partyInfoAddViewModel);
            

            var Actionresult = _inhabitantFactory.GetPartyInfoAddResViewModel();
            if (Party_add_Count > 0)
            {
                Actionresult.baseViewModel.IsSuccess = true;
                Actionresult.AddCount = Party_add_Count;
                Actionresult.baseViewModel.Message = "添加成功";
                Actionresult.baseViewModel.ResponseCode = 200;
                _ILogger.Information("增添信息成功");
                return Ok(Actionresult);
            }
            else
            {
                Actionresult.baseViewModel.IsSuccess = false;
                Actionresult.AddCount = 0;
                Actionresult.baseViewModel.Message = "添加失败";
                Actionresult.baseViewModel.ResponseCode = 400;
                _ILogger.Information("增添信息失败");
                return BadRequest(Actionresult);
            }
            

        }
        /// <summary>
        /// 更新党员信息
        /// </summary>
        /// <param name="partyInfoUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<PartyInfoUpdateResViewModel> Party_OpinionInfo_Update(PartyInfoUpdateViewModel partyInfoUpdateViewModel)
        {
            int Party_add_Count = 0;
            Party_add_Count = _partyService.PartyInfo_Update(partyInfoUpdateViewModel);


            var Actionresult = _inhabitantFactory.GetPartyInfoUpdateResViewModel();
            if (Party_add_Count > 0)
            {
                Actionresult.baseViewModel.IsSuccess = true;
                Actionresult.AddCount = Party_add_Count;
                Actionresult.baseViewModel.Message = "更改成功";
                Actionresult.baseViewModel.ResponseCode = 200;
                _ILogger.Information("更改信息成功");
                return Ok(Actionresult);
            }
            else
            {
                Actionresult.baseViewModel.IsSuccess = false;
                Actionresult.AddCount = 0;
                Actionresult.baseViewModel.Message = "更改失败";
                Actionresult.baseViewModel.ResponseCode = 400;
                _ILogger.Information("更改信息失败");
                return BadRequest(Actionresult);
            }

        }

        /// <summary>
        /// 查询未成年人员信息
        /// </summary>
        /// <param name="underAgerSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<UnderAgeSearchResViewModel> UnderAge_OpinionInfo_Search(UnderAgerSearchViewModel underAgerSearchViewModel)
        {
            var SearchResult = _inhabitantService.UnderAgeSearch(underAgerSearchViewModel);
            var Actionresult = _inhabitantFactory.GetUnderAgeSearchResViewModel();
            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }

        /// <summary>
        /// 查询教育适龄人员信息
        /// </summary>
        /// <param name="rightAgeSearchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<RightAgeSearchResViewModel> RightAge_OpinionInfo_Search(RightAgeSearchViewModel rightAgeSearchViewModel)
        {
            var SearchResult = _inhabitantService.RightAgeSearch(rightAgeSearchViewModel);

            var Actionresult = _inhabitantFactory.GetRightAgeSearchResViewModel();

            Actionresult.baseViewModel.IsSuccess = true;
            Actionresult.Data = SearchResult;
            Actionresult.baseViewModel.Message = "查询信息成功";
            Actionresult.baseViewModel.ResponseCode = 200;
            _ILogger.Information("查询信息成功");

            return Ok(Actionresult);

        }




    }
}