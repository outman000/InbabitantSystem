using AutoMapper;
using Dto.IRepository.ResidentialAreaSystem;
using Dto.IService.ResidentialAreaSystem;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.InhabitantSystem.RequestViewModel;
using ViewModel.ResidentialAreaSystem.MiddleViewModel;
using ViewModel.ResidentialAreaSystem.RequestViewModel;

namespace Dto.Service.ResidentialAreaSystem
{
    public class ResidentialAreaService : IResidentialAreaService
    {
       
        private readonly IResidentialAreaRepository _residentialAreaRepository;
        private readonly IMapper _IMapper;

        public ResidentialAreaService(IResidentialAreaRepository  residentialAreaRepository, IMapper mapper)
        {
            
            _residentialAreaRepository = residentialAreaRepository;
            _IMapper = mapper;
        }
        /// <summary>
        /// 添加小区信息
        /// </summary>
        /// <param name="areaAddViewModel"></param>
        /// <returns></returns>
        public int addArea(AreaAddViewModel areaAddViewModel)
        {
            var aAddInsertModel = _IMapper.Map<AreaAddViewModel, ResidentialArea>(areaAddViewModel);
            _residentialAreaRepository.Add(aAddInsertModel);
            return _residentialAreaRepository.SaveChanges();
        }
        /// <summary>
        /// 查询小区信息
        /// </summary>
        /// <param name="areaSearchViewModel"></param>
        /// <returns></returns>
        public List<AreaSearchMiddle> Area_Search(AreaSearchViewModel areaSearchViewModel)
        {
            var AreaSearchResult =_residentialAreaRepository.AreaSerachByWhere(areaSearchViewModel);
            var AreaSearchResultModel = _IMapper.Map<List<ResidentialArea>, List<AreaSearchMiddle>>(AreaSearchResult);
            return AreaSearchResultModel;
        }
        public int Area_SearchCount(AreaSearchViewModel areaSearchViewModel)
        {
            return _residentialAreaRepository.AreaSerachByWhereCount(areaSearchViewModel);
        }
        /// <summary>
        /// 更新小区信息
        /// </summary>
        /// <param name="areaUpdateViewModel"></param>
        /// <returns></returns>
        public int Area_Update(AreaUpdateViewModel areaUpdateViewModel)
        {
            var areaUpdateModel = _IMapper.Map<AreaUpdateViewModel, ResidentialArea>(areaUpdateViewModel);
            _residentialAreaRepository.Update(areaUpdateModel);
            return _residentialAreaRepository.SaveChanges();
        }

        public List<StatisticsViewModel> GetAllArea()
        {
            var AreaAllResult = _residentialAreaRepository.GetAll().ToList();
            var areaAllModel = _IMapper.Map<List<ResidentialArea>, List<StatisticsViewModel>>(AreaAllResult);

            return areaAllModel;
        }
    }
}
