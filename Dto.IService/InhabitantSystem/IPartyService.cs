using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.RequestViewModel;

namespace Dto.IService.InhabitantSystem
{
    public interface IPartyService
    {
        int AddPartyInfo(PartyInfoAddViewModel partyInfoAddViewModel);
        int PartyInfo_Update(PartyInfoUpdateViewModel partyInfoUpdateViewModel);
    }
}
