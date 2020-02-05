using AutoMapper;
using Dto.IRepository.InhabitantSystem;
using Dto.IService.InhabitantSystem;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.BuildingSystem.RequestViewModel;
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.InhabitantSystem.RequestViewModel;

namespace Dto.Service.InhabitantSystem
{
    public class HouseInfoService : IHouseInfoService
    {
        private readonly IHouseInfoRepository _houseInfoRepository;
        private readonly IMapper _IMapper;

        public HouseInfoService(IHouseInfoRepository houseInfoRepository, IMapper mapper)
        {
            _houseInfoRepository = houseInfoRepository;
            _IMapper = mapper;
        }



        /// <summary>
        /// 添加房屋信息
        /// </summary>
        /// <param name="houseInfoAddViewModel"></param>
        /// <returns></returns>
        public int AddHouseInfo(HouseInfoAddViewModel houseInfoAddViewModel)
        {
            var tempAddViewMiddle = houseInfoAddViewModel.houseInfoAddMiddles;
            var aAddInsertModel = _IMapper.Map<List<HouseInfoAddMiddle>, List<HouseInfo>>(tempAddViewMiddle);
            _houseInfoRepository.AddHouseInfo(aAddInsertModel);
            return _houseInfoRepository.SaveChanges();
        }
        /// <summary>
        /// 查询房子信息
        /// </summary>
        /// <param name="houseInfoSearchViewModel"></param>
        /// <returns></returns>
        public List<HouseInfoSearchMiddle> HouseInfo_Search(HouseInfoSearchViewModel houseInfoSearchViewModel)
        {
            var SearchResult = _houseInfoRepository.HouseInfoSerachByWhere(houseInfoSearchViewModel).ToList();
            var SearchResultModel = _IMapper.Map<List<HouseInfo>, List<HouseInfoSearchMiddle>>(SearchResult);
            return SearchResultModel;
        }
        /// <summary>
        /// 更新房子信息
        /// </summary>
        /// <param name="houseInfoUpdateViewModel"></param>
        /// <returns></returns>
        public int HouseInfo_Update(HouseInfoUpdateViewModel houseInfoUpdateViewModel)
        {
            var tempUpdateViewMiddle = houseInfoUpdateViewModel.houseInfoUpdateMiddles;
            var IdentityUpdateModel = _IMapper.Map<List<HouseInfoUpdateMiddle>, List<HouseInfo>>(tempUpdateViewMiddle);
            _houseInfoRepository.UpdateHouseInfo(IdentityUpdateModel);
            return _houseInfoRepository.SaveChanges();
        }
        /// <summary>
        /// 单一添加房子信息
        /// </summary>
        /// <param name="inhabitantAndHouseInfoAddMiddle"></param>
        /// <returns></returns>
        public int AddHouseInfoSingle(InhabitantAndHouseInfoAddMiddle inhabitantAndHouseInfoAddMiddle)
        {
            var aAddInsertModel = _IMapper.Map<InhabitantAndHouseInfoAddMiddle, HouseInfo>(inhabitantAndHouseInfoAddMiddle);

            _houseInfoRepository.Add(aAddInsertModel);
            return _houseInfoRepository.SaveChanges();
        }
        /// <summary>
        /// 根据小区名查 住户数量
        /// </summary>
        /// <param name="buildingSearchViewModel"></param>
        /// <returns></returns>
        public int HouseCountSearch(BuildingSearchViewModel buildingSearchViewModel)
        {
            return _houseInfoRepository.HouseCountByWhere(buildingSearchViewModel);
        }





    }
}
