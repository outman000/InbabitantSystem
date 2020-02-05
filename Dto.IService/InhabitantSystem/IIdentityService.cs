using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.InhabitantSystem.RequestViewModel;

namespace Dto.IService.InhabitantSystem
{
    public interface IIdentityService
    {
        int AddIdentity(IdentityAddViewModel identityAddViewModel);

        List<IdentitySearchMiddle> Identity_Search(IdentitySearchViewModel identitySearchViewModel);
        int Identity_SearchCount(IdentitySearchViewModel identitySearchViewModel);

        int Identity_Update(IdentityUpdateViewModel identityUpdateViewModel);
    }
}
