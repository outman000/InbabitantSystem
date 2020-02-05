using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BuildingSystem.RequestViewModel;
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.InhabitantSystem.RequestViewModel;

namespace Dto.IService.InhabitantSystem
{
    public interface IHouseInfoService
    {
        int AddHouseInfo(HouseInfoAddViewModel houseInfoAddViewModel);

        List<HouseInfoSearchMiddle> HouseInfo_Search(HouseInfoSearchViewModel houseInfoSearchViewModel);

        int HouseInfo_Update(HouseInfoUpdateViewModel houseInfoUpdateViewModel);

        int AddHouseInfoSingle(InhabitantAndHouseInfoAddMiddle inhabitantAndHouseInfoAddMiddle);
        //根据小区名查 住户数量
        int HouseCountSearch(BuildingSearchViewModel buildingSearchViewModel);
    }
}
