using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.InhabitantSystem.RequestViewModel;

namespace Dto.IRepository.InhabitantSystem
{
    public interface IIdentityRepository : IRepository<ResidentIdentity>
    {

        List<ResidentIdentity> IdentitySerachByWhere(IdentitySearchViewModel identitySearchViewModel);
        int IdentitySerachByWhereCount(IdentitySearchViewModel identitySearchViewModel);
        void AddIdentity(List<ResidentIdentity> obj);
        void UpdateIdentity(List<ResidentIdentity> obj);
    }
}
