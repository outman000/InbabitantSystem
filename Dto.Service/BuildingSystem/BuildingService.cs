using AutoMapper;
using Dto.IRepository.BuildingSystem;
using Dto.IRepository.ResidentialAreaSystem;
using Dto.IService.BuildingSystem;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.BuildingSystem.MiddleViewModel;
using ViewModel.BuildingSystem.RequestViewModel;

namespace Dto.Service.BuildingSystem
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _IMapper;
        public BuildingService(IBuildingRepository buildingRepository, IMapper mapper)
        {

            _buildingRepository = buildingRepository;
            _IMapper = mapper;
        }

        /// <summary>
        /// 添加楼宇信息
        /// </summary>
        /// <param name="buildingAddViewModel"></param>
        /// <returns></returns>
        public int AddBuilding(BuildingAddViewModel buildingAddViewModel)
        {
            var aAddInsertModel = _IMapper.Map<BuildingAddViewModel, Building>(buildingAddViewModel);
            _buildingRepository.Add(aAddInsertModel);
            return _buildingRepository.SaveChanges();
        }
        /// <summary>
        /// 查询楼宇信息
        /// </summary>
        /// <param name="buildingSearchViewModel"></param>
        /// <returns></returns>
        public List<BuildingSearchMiddleViewModel> Building_Search(BuildingSearchViewModel buildingSearchViewModel)
        {
            var BuildingSearchResult = _buildingRepository.BuildingSerachByWhere(buildingSearchViewModel).ToList();
            var BuildingSearchResultModel = _IMapper.Map<List<Building>, List<BuildingSearchMiddleViewModel>>(BuildingSearchResult);
            return BuildingSearchResultModel;
        }
        public int Building_SearchCount(BuildingSearchViewModel buildingSearchViewModel)
        {

            return _buildingRepository.BuildingSerachByWhereCount(buildingSearchViewModel);
        }
        /// <summary>
        /// 更新楼宇
        /// </summary>
        /// <param name="buildingUpdateViewModel"></param>
        /// <returns></returns>
        public int Building_Update(BuildingUpdateViewModel buildingUpdateViewModel)
        {
            var BuildingUpdateModel = _IMapper.Map<BuildingUpdateViewModel, Building>(buildingUpdateViewModel);
            _buildingRepository.Update(BuildingUpdateModel);
            return _buildingRepository.SaveChanges();
        }

        //楼栋数
        public int Building_SearchBuildingNoCount(BuildingSearchViewModel buildingSearchViewModel)
        {
            return _buildingRepository.BuildingSerachByWhereBuildingNoCount(buildingSearchViewModel);
        }
        //单元数
        public int Building_SearchUnitNoCount(BuildingSearchViewModel buildingSearchViewModel)
        {
            return _buildingRepository.BuildingSerachByWhereUnitNoCount(buildingSearchViewModel);
        }





    }
}
