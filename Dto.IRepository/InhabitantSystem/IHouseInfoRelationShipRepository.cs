using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.InhabitantSystem.RequestViewModel;

namespace Dto.IRepository.InhabitantSystem
{
    public interface IHouseInfoRelationShipRepository : IRepository<InfoRelationShip>
    {
        void AddHouseInfoRelationShip(List<InfoRelationShip> obj);

        void DeleteHouseInfoRelationShip(List<HouseInfoRelationShipDeleteMiddle> obj);
        List<InfoRelationShip> InfoRelationShipSerachByIdNoWhere(string IdNo);
    }
}
