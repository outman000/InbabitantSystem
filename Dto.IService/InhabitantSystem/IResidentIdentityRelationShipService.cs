using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.InhabitantSystem.RequestViewModel;

namespace Dto.IService.InhabitantSystem
{
    public interface IResidentIdentityRelationShipService
    {
        int AddResidentIdentityRelationShip(ResidentIdentityRelationShipAddViewModel residentIdentityRelationShipAddViewModel);

        int DeleteResidentIdentityRelationShip(ResidentIdentityRelationShipDeleteViewModel residentIdentityRelationShipDeleteViewModel);
    }
}
