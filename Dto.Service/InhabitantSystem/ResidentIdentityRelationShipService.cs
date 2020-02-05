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
    public class ResidentIdentityRelationShipService : IResidentIdentityRelationShipService
    {
        private readonly IResidentIdentityRelationShipRepository _residentIdentityRelationShipRepository;
        private readonly IMapper _IMapper;

        public ResidentIdentityRelationShipService(IResidentIdentityRelationShipRepository residentIdentityRelationShipRepository, IMapper mapper)
        {
            _residentIdentityRelationShipRepository = residentIdentityRelationShipRepository;
            _IMapper = mapper;
        }

        public int AddResidentIdentityRelationShip(ResidentIdentityRelationShipAddViewModel residentIdentityRelationShipAddViewModel)
        {
            var tempAddViewMiddle = residentIdentityRelationShipAddViewModel.residentIdentityRelationShipAddMiddles;
            var aAddInsertModel = _IMapper.Map<List<ResidentIdentityRelationShipAddMiddle>, List<ResidentRelationShip>>(tempAddViewMiddle);
            _residentIdentityRelationShipRepository.AddResidentIdentityRelationShip(aAddInsertModel);
            return _residentIdentityRelationShipRepository.SaveChanges();
        }

        public int DeleteResidentIdentityRelationShip(ResidentIdentityRelationShipDeleteViewModel residentIdentityRelationShipDeleteViewModel)
        {

            _residentIdentityRelationShipRepository.DeleteResidentIdentityRelationShip(residentIdentityRelationShipDeleteViewModel.residentIdentityRelationShipDeleteMiddles);
            return _residentIdentityRelationShipRepository.SaveChanges();
        }
    }
}
