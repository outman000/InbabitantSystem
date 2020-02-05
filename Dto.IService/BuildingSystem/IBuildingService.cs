using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BuildingSystem.MiddleViewModel;
using ViewModel.BuildingSystem.RequestViewModel;

namespace Dto.IService.BuildingSystem
{
    public interface IBuildingService
    {
        int AddBuilding(BuildingAddViewModel buildingAddViewModel);

        List<BuildingSearchMiddleViewModel> Building_Search(BuildingSearchViewModel buildingSearchViewModel);
        int Building_SearchCount(BuildingSearchViewModel buildingSearchViewModel);

        int Building_Update(BuildingUpdateViewModel buildingUpdateViewModel);
        //楼栋数
        int Building_SearchBuildingNoCount(BuildingSearchViewModel buildingSearchViewModel);
        //单元数
        int Building_SearchUnitNoCount(BuildingSearchViewModel buildingSearchViewModel);
    }
}
