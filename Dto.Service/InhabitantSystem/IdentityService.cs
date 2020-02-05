using AutoMapper;
using Dto.IRepository.InhabitantSystem;
using Dto.IService.InhabitantSystem;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.InhabitantSystem.RequestViewModel;

namespace Dto.Service.InhabitantSystem
{
    public class IdentityService : IIdentityService
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly IMapper _IMapper;

        public IdentityService(IIdentityRepository identityRepository, IMapper mapper)
        {
            _identityRepository = identityRepository;
            _IMapper = mapper;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="identityAddViewModel"></param>
        /// <returns></returns>
        public int AddIdentity(IdentityAddViewModel identityAddViewModel)
        {
            var tempAddViewMiddle = identityAddViewModel.identityAddMiddles;
            var aAddInsertModel = _IMapper.Map<List<IdentityAddMiddle>, List<ResidentIdentity>>(tempAddViewMiddle);
            _identityRepository.AddIdentity(aAddInsertModel);
            return _identityRepository.SaveChanges();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="identitySearchViewModel"></param>
        /// <returns></returns>
        public List<IdentitySearchMiddle> Identity_Search(IdentitySearchViewModel identitySearchViewModel)
        {
            var IdentitySearchResult = _identityRepository.IdentitySerachByWhere(identitySearchViewModel).ToList();
            var IdentitySearchResultModel = _IMapper.Map<List<ResidentIdentity>, List<IdentitySearchMiddle>>(IdentitySearchResult);
            return IdentitySearchResultModel;
        }
        public int Identity_SearchCount(IdentitySearchViewModel identitySearchViewModel)
        {
            return _identityRepository.IdentitySerachByWhereCount(identitySearchViewModel);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="identityUpdateViewModel"></param>
        /// <returns></returns>
        public int Identity_Update(IdentityUpdateViewModel identityUpdateViewModel)
        {
            var tempUpdateViewMiddle = identityUpdateViewModel.identityUpdateViewModel;
            var IdentityUpdateModel = _IMapper.Map<List<IdentityUpdateMiddle>, List<ResidentIdentity>>(tempUpdateViewMiddle);
            _identityRepository.UpdateIdentity(IdentityUpdateModel);
            return _identityRepository.SaveChanges();
        }
    }
}
