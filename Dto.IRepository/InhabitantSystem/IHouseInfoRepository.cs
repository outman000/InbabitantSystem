using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.BuildingSystem.RequestViewModel;
using ViewModel.InhabitantSystem.RequestViewModel;

namespace Dto.IRepository.InhabitantSystem
{
    public interface IHouseInfoRepository : IRepository<HouseInfo>
    {
        IQueryable<HouseInfo> HouseInfoSerachByWhere(HouseInfoSearchViewModel houseInfoSearchViewModel);
        void AddHouseInfo(List<HouseInfo> obj);
        void UpdateHouseInfo(List<HouseInfo> obj);

        int HouseCountByWhere(BuildingSearchViewModel buildingSearchViewModel);
    }
}
