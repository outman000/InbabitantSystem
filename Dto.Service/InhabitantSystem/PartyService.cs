using AutoMapper;
using Dto.IRepository.InhabitantSystem;
using Dto.IService.InhabitantSystem;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.RequestViewModel;

namespace Dto.Service.InhabitantSystem
{
    public class PartyService : IPartyService
    {
        private readonly IPartyInfoRepository _partyInfoRepository;
        private readonly IMapper _IMapper;
        public PartyService(IPartyInfoRepository partyInfoRepository, IMapper mapper)
        {

            _partyInfoRepository = partyInfoRepository;
            _IMapper = mapper;
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
        /// 更新党员信息
        /// </summary>
        /// <param name="partyInfoUpdateViewModel"></param>
        /// <returns></returns>
        public int PartyInfo_Update(PartyInfoUpdateViewModel partyInfoUpdateViewModel)
        {
            var updateInsertModel = _IMapper.Map<PartyInfoUpdateViewModel, PartyInfo>(partyInfoUpdateViewModel);
            _partyInfoRepository.Update(updateInsertModel);
            return _partyInfoRepository.SaveChanges();
        }
    }
}
