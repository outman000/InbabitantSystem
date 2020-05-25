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
        private readonly IMapper _IMapper;
        public InhabitantService(IInhabitantRepository inhabitantRepository, IHouseInfoRelationShipRepository  houseInfoRelationShipRepository,
              IMapper mapper)
        {

            _inhabitantRepository = inhabitantRepository;
            _houseInfoRelationShipRepository = houseInfoRelationShipRepository;
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
        /// 批量更新
        /// </summary>
        /// <param name="inhabitantUpdateViewModel"></param>
        /// <returns></returns>
        public int Inhabitant_Update(InhabitantUpdateViewModel inhabitantUpdateViewModel)
        {
            var tempUpdateViewMiddle = inhabitantUpdateViewModel.inhabitantUpdateViewModel;
            var InhabitantUpdateModel = _IMapper.Map<List<InhabitantUpdateMiddle>, List<ResidentInfo>>(tempUpdateViewMiddle);

            //var InfoRelationShip =  _IMapper.Map<List<InhabitantUpdateMiddle>, List<InfoRelationShip>>(tempUpdateViewMiddle);

            for (int i = 0; i < InhabitantUpdateModel.Count; i++)
            {
                var InfoRelationShip = _houseInfoRelationShipRepository.InfoRelationShipSerachByIdNoWhere(InhabitantUpdateModel[i].Id.ToString());
                for (int j = 0; j < InfoRelationShip.Count; j++)
                {
                    InfoRelationShip[j].RelationWithHousehold = tempUpdateViewMiddle[i].RelationWithHousehold;
                    _houseInfoRelationShipRepository.Update(InfoRelationShip[j]);
                  
                }

            }
            _houseInfoRelationShipRepository.SaveChanges();
            _inhabitantRepository.UpdateInfo(InhabitantUpdateModel);




            return _inhabitantRepository.SaveChanges();
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
