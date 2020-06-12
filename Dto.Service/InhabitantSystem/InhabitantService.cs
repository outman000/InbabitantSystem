using AutoMapper;
using Dto.IRepository.InhabitantSystem;
using Dto.IService.InhabitantSystem;
using Dtol.Dtol;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.InhabitantSystem.RequestViewModel;
using ViewModel.InhabitantSystem.ResponseViewModel;

namespace Dto.Service.InhabitantSystem
{
    public class InhabitantService : IInhabitantService
    {
        private readonly IInhabitantRepository _inhabitantRepository;
        private readonly IHouseInfoRelationShipRepository _houseInfoRelationShipRepository;
        private readonly IPartyInfoRepository _partyInfoRepository;
        private readonly IHouseInfoRepository _houseInfoRepository;
        private readonly IMapper _IMapper;
        public InhabitantService(IInhabitantRepository inhabitantRepository, IHouseInfoRelationShipRepository  houseInfoRelationShipRepository,
                                 IHouseInfoRepository houseInfoRepository, IPartyInfoRepository partyInfoRepository, IMapper mapper)
        {

            _inhabitantRepository = inhabitantRepository;
            _houseInfoRelationShipRepository = houseInfoRelationShipRepository;
            _partyInfoRepository = partyInfoRepository;
            _houseInfoRepository = houseInfoRepository;
            _IMapper = mapper;
        }
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="inhabitantAddViewModel"></param>
        /// <returns></returns>
        public int AddInhabitant(InhabitantAddViewModel inhabitantAddViewModel)
        {
            var tempAddViewMiddle = inhabitantAddViewModel.inhabitantAddViewModel;
            var aAddInsertModel = _IMapper.Map<List<InhabitantAddMiddle>, List<ResidentInfo>>(tempAddViewMiddle);
            
            _inhabitantRepository.AddInfo(aAddInsertModel);
            return _inhabitantRepository.SaveChanges();
        }
        /// <summary>
        /// 根据身份证号 查居民
        /// </summary>
        /// <param name="IdNo"></param>
        /// <returns></returns>
        public ResidentInfo Inhabitant_ByIdNo_Search(string IdNo)
        {
           return _inhabitantRepository.InhabitantSerachByIdNoWhere(IdNo);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="inhabitantSearchViewModel"></param>
        /// <returns></returns>
        public List<InhabitantSearchMiddle> Inhabitant_Search(InhabitantSearchViewModel inhabitantSearchViewModel)
        {
            var InhabitantSearchResult = _inhabitantRepository.InhabitantSerachByWhere(inhabitantSearchViewModel).ToList();
            var InhabitantSearchResultModel = _IMapper.Map<List<ResidentInfo>, List<InhabitantSearchMiddle>>(InhabitantSearchResult);
            return InhabitantSearchResultModel;
        }

        /// <summary>
        /// 单一添加房子和居民关系
        /// </summary>
        /// <param name="inhabitantAndHouseInfoAddMiddle"></param>
        /// <returns></returns>
        public int AddHouseInfoRelationShipSingle(InhabitantAndHouseInfoAddMiddle inhabitantAndHouseInfoAddMiddle)
        {
            var aAddInsertModel = _IMapper.Map<InhabitantAndHouseInfoAddMiddle, InfoRelationShip>(inhabitantAndHouseInfoAddMiddle);

            _houseInfoRelationShipRepository.Add(aAddInsertModel);
            return _houseInfoRelationShipRepository.SaveChanges();
        }

        ///// <summary>
        ///// 批量更新
        ///// </summary>
        ///// <param name="inhabitantUpdateViewModel"></param>
        ///// <returns></returns>
        //public int Inhabitant_Update(InhabitantUpdateViewModel inhabitantUpdateViewModel)
        //{
        //    var tempUpdateViewMiddle = inhabitantUpdateViewModel.inhabitantUpdateViewModel;
        //    var InhabitantUpdateModel = _IMapper.Map<List<InhabitantUpdateMiddle>, List<ResidentInfo>>(tempUpdateViewMiddle);
        //  //  var InfoRelationShip = _IMapper.Map<List<InhabitantUpdateMiddle>, List<InfoRelationShip>>(tempUpdateViewMiddle);

        //    //int InhabitantAndHouseInfo_add_Count = 0;
        //    //foreach (InhabitantUpdateMiddle model in inhabitantUpdateViewModel.inhabitantUpdateViewModel)
        //    //{
        //    //    //验证居民是否重复
        //    //    var checkInhabitant = Inhabitant_ByIdNo_Search(model.IdNumber);
        //    //    if (checkInhabitant != null)
        //    //    {
        //    //        //  var tempUpdateViewMiddle = inhabitantUpdateViewModel.inhabitantUpdateViewModel;
        //    //        var  InhabitantUpdateModel = _IMapper.Map<InhabitantUpdateMiddle, ResidentInfo>(model);
        //    for (int i = 0; i < tempUpdateViewMiddle.Count; i++)
        //    {
        //          var InfoRelationShip = _houseInfoRelationShipRepository.InfoRelationShipSerachByIdNoWhere(tempUpdateViewMiddle[i].Id.ToString());
        //                for (int j = 0; j < InfoRelationShip.Count; j++)
        //                {
        //                    InfoRelationShip[j].RelationWithHousehold = tempUpdateViewMiddle[i].RelationWithHousehold;
        //                    _houseInfoRelationShipRepository.Update(InfoRelationShip[j]);
        //                }                      
        //         //   }
        //            _houseInfoRelationShipRepository.SaveChanges();
        //            _inhabitantRepository.UpdateInfo(InhabitantUpdateModel);
        //            //InhabitantAndHouseInfo_add_Count++;

        //        //else
        //        //{
        //        //    InhabitantAndHouseInfoAddMiddle ia = new InhabitantAndHouseInfoAddMiddle();

        //        //    var aAddInsertModel = _IMapper.Map<InhabitantUpdateMiddle, InhabitantAndHouseInfoAddMiddle>(model);
        //        //    //  var infos= _inhabitantRepository.GetById(model.HouseHolderId.Value);

        //        //    var infos = _houseInfoRelationShipRepository.InfoRelationShipSerachByIdNoWhere(model.HouseHolderId.Value.ToString());
        //        //    aAddInsertModel.HouseId = infos[0].HouseInfoId;
        //        //    aAddInsertModel.RelationShipId = Guid.NewGuid();
        //        //    aAddInsertModel.InhabitantId = Guid.NewGuid();
        //        //    //添加居民信息
        //        //    AddInhabitantSingle(aAddInsertModel);

        //        //    //添加居民和房子关系
        //        //    AddHouseInfoRelationShipSingle(aAddInsertModel);
        //        //    InhabitantAndHouseInfo_add_Count++;
        //        //    //添加党员信息
        //        //    if (aAddInsertModel.Politics == "中共党员")
        //        //    {
        //        //        PartyInfoAddViewModel partyInfoAddViewModel = new PartyInfoAddViewModel();
        //        //        partyInfoAddViewModel.ResidentId = aAddInsertModel.InhabitantId;
        //        //        partyInfoAddViewModel.IdNumber = aAddInsertModel.IdNumber;

        //        //        int Party_add_Count = 0;
        //        //        Party_add_Count = AddPartyInfo(partyInfoAddViewModel);
        //        //    }

        //        //}


        //    }


        //    return _inhabitantRepository.SaveChanges();
        //}



        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="inhabitantUpdateViewModel"></param>
        /// <returns></returns>
        public int Inhabitant_Update(InhabitantUpdateViewModel inhabitantUpdateViewModel)
        {
            int InhabitantAndHouseInfo_add_Count = 0;
            foreach (InhabitantUpdateMiddle model in inhabitantUpdateViewModel.inhabitantUpdateViewModel)
            {
                if (model.Id != null)//说明是修改
                {
                    var residentInfo = _inhabitantRepository.GetById(model.Id.Value);                    var houseInfo = _houseInfoRepository.GetByHouseHolderIdNo(residentInfo.IdNumber);
            
                     residentInfo = _IMapper.Map<InhabitantUpdateMiddle, ResidentInfo>(model, residentInfo);//修改居民信息
                    _inhabitantRepository.Update(residentInfo);
                    _inhabitantRepository.SaveChanges();

                    if(houseInfo.Count>0)//说明是房主
                    {
                         var result= _IMapper.Map<ResidentInfo, ResidentInfoMiddleId>(residentInfo); 
                         houseInfo[0] = _IMapper.Map<ResidentInfoMiddleId, HouseInfo>(result, houseInfo[0]);//修改房屋信息

                        var SearchResult = _houseInfoRepository.HouseInfoSerachByWhere3(model).ToList();
                        if (SearchResult.Count > 0 && houseInfo[0].Id != SearchResult[0].Id)
                        {

                            return 999999;

                        }

                        houseInfo[0].Area = model.Area;// 小区名称
                         houseInfo[0].BuildingNo = model.BuildingNo;// 楼号
                         houseInfo[0].UnitNo= model.UnitNo;// 单元号
                         houseInfo[0].HouseNo = model.HouseNo;// 门牌号

                        _houseInfoRepository.Update(houseInfo[0]);
                        _houseInfoRepository.SaveChanges();
                    }
                    
                    var InfoRelationShip = _houseInfoRelationShipRepository.InfoRelationShipSerachByIdNoWhere(residentInfo.Id.ToString());
                    for (int j = 0; j < InfoRelationShip.Count; j++)
                    {
                        InfoRelationShip[j].RelationWithHousehold = model.RelationWithHousehold;
                        _houseInfoRelationShipRepository.Update(InfoRelationShip[j]);
                    }
                    _houseInfoRelationShipRepository.SaveChanges();
               
                    InhabitantAndHouseInfo_add_Count++;
                }
                else//说明是新增
                {
                    InhabitantAndHouseInfoAddMiddle ia = new InhabitantAndHouseInfoAddMiddle();
                    var aAddInsertModel = _IMapper.Map<InhabitantUpdateMiddle, InhabitantAndHouseInfoAddMiddle>(model);
                     var infos = _houseInfoRelationShipRepository.InfoRelationShipSerachByIdNoWhere(model.HouseHolderId.Value.ToString());

                    //var infos =_houseInfoRepository.GetByHouseHolderIdNo(model.HouseHolderId.Value.ToString());
                    aAddInsertModel.HouseId = infos[0].HouseInfoId;
                    aAddInsertModel.RelationShipId = Guid.NewGuid();
                    aAddInsertModel.InhabitantId = Guid.NewGuid();
                    //添加居民信息
                    AddInhabitantSingle(aAddInsertModel);

                    //添加居民和房子关系
                    AddHouseInfoRelationShipSingle(aAddInsertModel);
                    InhabitantAndHouseInfo_add_Count++;
                    //添加党员信息
                    if (aAddInsertModel.Politics == "中共党员")
                    {
                        PartyInfoAddViewModel partyInfoAddViewModel = new PartyInfoAddViewModel();
                        partyInfoAddViewModel.ResidentId = aAddInsertModel.InhabitantId;
                        partyInfoAddViewModel.IdNumber = aAddInsertModel.IdNumber;

                        int Party_add_Count = 0;
                        Party_add_Count = AddPartyInfo(partyInfoAddViewModel);
                    }

                }


            }


            return InhabitantAndHouseInfo_add_Count;
        }

        /// <summary>
        /// 添加党员信息
        /// </summary>
        /// <param name="partyInfoAddViewModel"></param>
        /// <returns></returns>
        public int AddPartyInfo(PartyInfoAddViewModel partyInfoAddViewModel)
        {
            var aAddInsertModel = _IMapper.Map<PartyInfoAddViewModel, PartyInfo>(partyInfoAddViewModel);
            _partyInfoRepository.Add(aAddInsertModel);
            return _partyInfoRepository.SaveChanges();
        }

        /// <summary>
        /// 单一插入居民信息
        /// </summary>
        /// <param name="inhabitantAndHouseInfoAddMiddle"></param>
        /// <returns></returns>
        public int AddInhabitantSingle(InhabitantAndHouseInfoAddMiddle inhabitantAndHouseInfoAddMiddle)
        {
            
            var aAddInsertModel = _IMapper.Map<InhabitantAndHouseInfoAddMiddle, ResidentInfo>(inhabitantAndHouseInfoAddMiddle);

            _inhabitantRepository.Add(aAddInsertModel);
            return _inhabitantRepository.SaveChanges();
        }


      


        /// <summary>
        /// 查询党员的居民信息
        /// </summary>
        /// <param name="partyResidentSearchViewModel"></param>
        /// <returns></returns>
        public List<PartyResidentSearchMiddle> getPartResidentSearch(PartyResidentSearchViewModel partyResidentSearchViewModel)
        {
            return _inhabitantRepository.getPartResidentSearch(partyResidentSearchViewModel);
        }
        public int getPartResidentSearchCount(PartyResidentSearchViewModel partyResidentSearchViewModel)
        {
            return _inhabitantRepository.getPartResidentSearchCount(partyResidentSearchViewModel);
        }
        /// <summary>
        /// 根据id查询党员的居民信息
        /// </summary>
        /// <param name="partyResidentByIdSearchViewModel"></param>
        /// <returns></returns>
        public PartyResidentByIdSearchMiddle getPartResidentByIdSearch(PartyResidentByIdSearchViewModel partyResidentByIdSearchViewModel)
        {
            return _inhabitantRepository.getPartResidentByIdSearch(partyResidentByIdSearchViewModel);
        }



        public List<UnderAgeSearchMiddle> UnderAgeSearch(UnderAgerSearchViewModel underAgerSearchViewModel)
        {
            return _inhabitantRepository.GetUnderAgeSearch(underAgerSearchViewModel);
        }

        public List<RightAgeSearchMiddle> RightAgeSearch(RightAgeSearchViewModel rightAgeSearchViewModel)
        {
            return _inhabitantRepository.GetRightAgeSearch(rightAgeSearchViewModel);
        }

  
    }
}
