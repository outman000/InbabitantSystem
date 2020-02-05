using Dto.IRepository.ResidentialAreaSystem;
using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.BuildingSystem.RequestViewModel;

namespace Dto.IRepository.BuildingSystem
{
    public interface IBuildingRepository :IRepository<Building>
    {
        //属于实体自己 的方法
        List<Building> BuildingSerachByWhere(BuildingSearchViewModel buildingSearchViewModel);

        int BuildingSerachByWhereCount(BuildingSearchViewModel buildingSearchViewModel);
        //根据检索条件  统计有多少栋楼
        int BuildingSerachByWhereBuildingNoCount(BuildingSearchViewModel buildingSearchViewModel);
        //根据检索条件 统计有多少个单元
        int BuildingSerachByWhereUnitNoCount(BuildingSearchViewModel buildingSearchViewModel);


    }
}
