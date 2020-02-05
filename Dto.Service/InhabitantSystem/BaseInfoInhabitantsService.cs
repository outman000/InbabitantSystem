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
    public class BaseInfoInhabitantsService : IBaseInfoInhabitantsService
    {
        private readonly IBaseInfoInhabitantsRepository _baseInfoInhabitantsRepository;
        private readonly IMapper _IMapper;

        public BaseInfoInhabitantsService(IBaseInfoInhabitantsRepository baseInfoInhabitantsRepository, IMapper mapper)
        {
            _baseInfoInhabitantsRepository = baseInfoInhabitantsRepository;
            _IMapper = mapper;
        }

        /// <summary>
        /// 通知页面 根据房屋信息，身份，人员信息 查询
        /// </summary>
        /// <param name="baseInfoInhabitantViewModel"></param>
        /// <returns></returns>
        public List<BaseInfoInhabitantMiddle> getResidentByAllInfo(BaseInfoInhabitantViewModel baseInfoInhabitantViewModel)
        {
            var SearchResult = _baseInfoInhabitantsRepository.getResidentByAllInfo(baseInfoInhabitantViewModel);
            //var SearchResultMiddle = _IMapper.Map<List<ResidentInfo>, List<ResidentMiddle>>(SearchResult);
            //var SearchResultModel = _IMapper.Map<List<ResidentMiddle>, List<BaseInfoInhabitantMiddle>>(SearchResultMiddle);
            return SearchResult;
            //return  _baseInfoInhabitantsRepository.getResidentByAllInfo();
        }
        public int getResidentByAllInfoCount(BaseInfoInhabitantViewModel baseInfoInhabitantViewModel)
        {
            return _baseInfoInhabitantsRepository.getResidentByAllInfoCount(baseInfoInhabitantViewModel);
        }
        /// <summary>
        /// 查询添加身份时 查询不是该身份的居民信息
        /// </summary>
        /// <param name="addIdentitySearchResidentViewModel"></param>
        /// <returns></returns>
        public List<AddIdentitySearchResidentMiddle> getAddIdentitySearchResident(AddIdentitySearchResidentViewModel addIdentitySearchResidentViewModel)
        {
            var SearchResult = _baseInfoInhabitantsRepository.getAddIdentitySearchResident(addIdentitySearchResidentViewModel);
            
            return SearchResult;
        }
        public int getAddIdentitySearchResidentCount(AddIdentitySearchResidentViewModel addIdentitySearchResidentViewModel)
        {
            return _baseInfoInhabitantsRepository.getAddIdentitySearchResidentCount(addIdentitySearchResidentViewModel);
        }
        /// <summary>
        /// 查询身份时  查询是该身份的居民
        /// </summary>
        /// <param name="identitySearchResidentViewModel"></param>
        /// <returns></returns>
        public List<IdentitySearchResidentMiddle> getIdentitySearchResident(IdentitySearchResidentViewModel identitySearchResidentViewModel)
        {
            return _baseInfoInhabitantsRepository.getIdentitySearchResident(identitySearchResidentViewModel);
        }
        public int getIdentitySearchResidentCount(IdentitySearchResidentViewModel identitySearchResidentViewModel)
        {
            return _baseInfoInhabitantsRepository.getIdentitySearchResidentCount(identitySearchResidentViewModel);
        }


        /// <summary>
        /// 居民信息查询时  查询的信息
        /// </summary>
        /// <param name="addIdentitySearchResidentViewModel"></param>
        /// <returns></returns>
        public List<ResidentInfoSearchMiddle> getResidentInfoSearchResident(ResidentInfoSearchViewModel residentInfoSearchViewModel)
        {
            return _baseInfoInhabitantsRepository.getResidentInfoSearchResident(residentInfoSearchViewModel);
        }
        public int getResidentInfoSearchResidentCount(ResidentInfoSearchViewModel residentInfoSearchViewModel)
        {
            return _baseInfoInhabitantsRepository.getResidentInfoSearchResidentCount(residentInfoSearchViewModel);

        }
        /// <summary>
        /// 根据具体房子信息查询
        /// </summary>
        /// <param name="byHouseInfoSearchResidentViewModel"></param>
        /// <returns></returns>
        public List<ByHouseInfoSearchResidentMiddle> getByHouseInfoSearchResident(ByHouseInfoSearchResidentViewModel byHouseInfoSearchResidentViewModel)
        {
            return _baseInfoInhabitantsRepository.getByHouseInfoSearchResident(byHouseInfoSearchResidentViewModel);
        }

    }
}
