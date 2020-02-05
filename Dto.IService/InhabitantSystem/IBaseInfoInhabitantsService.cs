using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.InhabitantSystem.RequestViewModel;

namespace Dto.IService.InhabitantSystem
{
    public interface IBaseInfoInhabitantsService
    {
        List<BaseInfoInhabitantMiddle> getResidentByAllInfo(BaseInfoInhabitantViewModel baseInfoInhabitantViewModel);
        int getResidentByAllInfoCount(BaseInfoInhabitantViewModel baseInfoInhabitantViewModel);

        List<AddIdentitySearchResidentMiddle> getAddIdentitySearchResident(AddIdentitySearchResidentViewModel addIdentitySearchResidentViewModel);
        int getAddIdentitySearchResidentCount(AddIdentitySearchResidentViewModel addIdentitySearchResidentViewModel);

        List<ResidentInfoSearchMiddle> getResidentInfoSearchResident(ResidentInfoSearchViewModel residentInfoSearchViewModel);
        int getResidentInfoSearchResidentCount(ResidentInfoSearchViewModel residentInfoSearchViewModel);
        List<ByHouseInfoSearchResidentMiddle> getByHouseInfoSearchResident(ByHouseInfoSearchResidentViewModel byHouseInfoSearchResidentViewModel);

        List<IdentitySearchResidentMiddle> getIdentitySearchResident(IdentitySearchResidentViewModel identitySearchResidentViewModel);
        int getIdentitySearchResidentCount(IdentitySearchResidentViewModel identitySearchResidentViewModel);



    }
}
