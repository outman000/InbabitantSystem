using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;

namespace Dto.IRepository.InhabitantSystem
{
    public interface IResidentIdentityRelationShipRepository : IRepository<ResidentRelationShip>
    {
        void AddResidentIdentityRelationShip(List<ResidentRelationShip> obj);

        void DeleteResidentIdentityRelationShip(List<ResidentIdentityRelationShipDeleteMiddle> obj);
    }
}
