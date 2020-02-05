using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.InhabitantSystem.RequestViewModel;

namespace Dto.IService.InhabitantSystem
{
    public interface IHouseInfoRelationShipService
    {
        int AddHouseInfoRelationShip(HouseInfoRelationShipAddViewModel houseInfoRelationShipAddViewModel);

        int AddHouseInfoRelationShipSingle(InhabitantAndHouseInfoAddMiddle inhabitantAndHouseInfoAddMiddle);

        int DeleteHouseInfoRelationShip(HouseInfoRelationShipDeleteViewModel houseInfoRelationShipDeleteViewModel);
    }
}
