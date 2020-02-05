using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.InhabitantSystem.RequestViewModel;
using ViewModel.InhabitantSystem.ResponseViewModel;

namespace Dto.IService.InhabitantSystem
{
    public interface IInhabitantService
    {
        int AddInhabitant(InhabitantAddViewModel inhabitantAddViewModel);

        List<InhabitantSearchMiddle> Inhabitant_Search(InhabitantSearchViewModel inhabitantSearchViewModel);

        int Inhabitant_Update(InhabitantUpdateViewModel inhabitantUpdateViewModel);

        ResidentInfo Inhabitant_ByIdNo_Search(string IdNo);

        int AddInhabitantSingle(InhabitantAndHouseInfoAddMiddle inhabitantAndHouseInfoAddMiddle);

        List<PartyResidentSearchMiddle> getPartResidentSearch(PartyResidentSearchViewModel partyResidentSearchViewModel);
        int getPartResidentSearchCount(PartyResidentSearchViewModel partyResidentSearchViewModel);
        PartyResidentByIdSearchMiddle getPartResidentByIdSearch(PartyResidentByIdSearchViewModel partyResidentByIdSearchViewModel);

        List<UnderAgeSearchMiddle> UnderAgeSearch(UnderAgerSearchViewModel underAgerSearchViewModel);


        List<RightAgeSearchMiddle> RightAgeSearch(RightAgeSearchViewModel rightAgerSearchViewModel);


    }
}
