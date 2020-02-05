using AutoMapper;
using Dto.IRepository.InhabitantSystem;
using Dto.IService.InhabitantSystem;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.InhabitantSystem.RequestViewModel;

namespace Dto.Service.InhabitantSystem
{
    public class HouseInfoRelationShipService : IHouseInfoRelationShipService
    {
        private readonly IHouseInfoRelationShipRepository _houseInfoRelationShipRepository;
        private readonly IMapper _IMapper;

        public HouseInfoRelationShipService(IHouseInfoRelationShipRepository houseInfoRelationShipRepository, IMapper mapper)
        {
            _houseInfoRelationShipRepository = houseInfoRelationShipRepository;
            _IMapper = mapper;
        }

        /// <summary>
        /// 添加房子很居民的关系
        /// </summary>
        /// <param name="houseInfoRelationShipAddViewModel"></param>
        /// <returns></returns>
        public int AddHouseInfoRelationShip(HouseInfoRelationShipAddViewModel houseInfoRelationShipAddViewModel)
        {
            var tempAddViewMiddle = houseInfoRelationShipAddViewModel.houseInfoRelationShipAddMiddles;
            var aAddInsertModel = _IMapper.Map<List<HouseInfoRelationShipAddMiddle>, List<InfoRelationShip>>(tempAddViewMiddle);
            _houseInfoRelationShipRepository.AddHouseInfoRelationShip(aAddInsertModel);
            return _houseInfoRelationShipRepository.SaveChanges();
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
        /// <summary>
        /// 批量删除房子和居民的关系
        /// </summary>
        /// <param name="houseInfoRelationShipDeleteViewModel"></param>
        /// <returns></returns>
        public int DeleteHouseInfoRelationShip(HouseInfoRelationShipDeleteViewModel houseInfoRelationShipDeleteViewModel)
        {

            _houseInfoRelationShipRepository.DeleteHouseInfoRelationShip(houseInfoRelationShipDeleteViewModel.houseInfoRelationShipDeleteMiddles);
            return _houseInfoRelationShipRepository.SaveChanges();
        }



    }
}
