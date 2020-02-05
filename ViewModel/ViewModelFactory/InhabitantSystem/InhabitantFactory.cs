using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.RequestViewModel;
using ViewModel.InhabitantSystem.ResponseViewModel;
using ViewModel.IViewModelFactory.InhabitantSystem;

namespace ViewModel.ViewModelFactory.InhabitantSystem
{
    public class InhabitantFactory : IInhabitantFactory
    {
        public BaseInfoInhabitantsResViewModel GetBaseInfoInhabitantsResViewModel()
        {
            return new BaseInfoInhabitantsResViewModel();
        }

        public HouseInfoAddResViewModel GetHouseInfoAddResViewModel()
        {
            return new HouseInfoAddResViewModel();
        }

        public HouseInfoSearchResViewModel GetHouseInfoSearchResViewModel()
        {
            return new HouseInfoSearchResViewModel();
        }

        public HouseInfoUpdateResViewModel GetHouseInfoUpdateResViewModel()
        {
            return new HouseInfoUpdateResViewModel();
        }

        public IdentityAddResViewModel GetIdentityAddResViewModel()
        {
            return new IdentityAddResViewModel();
        }

        public IdentitySearchResViewModel GetIdentitySearchResViewModel()
        {
            return new IdentitySearchResViewModel();
        }

        public IdentityUpdateResViewModel GetIdentityUpdateResViewModel()
        {
            return new IdentityUpdateResViewModel();
        }

        public InhabitantAddResViewModel GetInhabitantAddResViewModel()
        {
            return new InhabitantAddResViewModel();
        }

        public InhabitantSearchResModel GetInhabitantSearchResViewModel()
        {
            return new InhabitantSearchResModel();
        }

        public InhabitantUpdateResViewModel GetInhabitantUpdateResViewModel()
        {
            return new InhabitantUpdateResViewModel();
        }
        public HouseInfoRelationShipAddResViewModel GetHouseInfoRelationShipAddResViewModel()
        {
            return new HouseInfoRelationShipAddResViewModel();
        }

        public ResidentIdentityRelationShipAddResViewModel GetResidentIdentityRelationShipAddResViewModel()
        {
            return new ResidentIdentityRelationShipAddResViewModel();
        }

        public AddIdentitySearchResidentResViewModel GetAddIdentitySearchResidentResViewModel()
        {
            return new AddIdentitySearchResidentResViewModel();
        }

        public AreaPopulationStatisticsResViewModel GetAreaPopulationStatisticsResViewModel()
        {
            return new AreaPopulationStatisticsResViewModel();
        }

        
        public AgeStatisticsResViewModel GetAgeStatisticsResViewModel()
        {
            return new AgeStatisticsResViewModel();
        }
        
        public GenderStatisticsResViewModel GetGenderStatisticsResViewModel()
        {
            return new GenderStatisticsResViewModel();
        }
        public InhabitantAndHouseInfoAddResViewModel GetInhabitantAndHouseInfoAddResViewModel()
        {
            return new InhabitantAndHouseInfoAddResViewModel();
        }

        public ResidentInfoSearchResViewModel GetResidentInfoSearchResViewModel()
        {
            return new ResidentInfoSearchResViewModel();
        }

        public ByHouseInfoSearchResidentResViewModel GetByHouseInfoSearchResidentResViewModel()
        {
            return new ByHouseInfoSearchResidentResViewModel();
        }

        public PartyResidentSearchResViewModel GetPartyResidentSearchResViewModel()
        {
            return new PartyResidentSearchResViewModel();
        }

        public PartyResidentByIdSearchResViewModel GetPartyResidentByIdSearchResViewModel()
        {
            return new PartyResidentByIdSearchResViewModel ();
        }

        public PartyInfoAddResViewModel GetPartyInfoAddResViewModel()
        {
            return new PartyInfoAddResViewModel();
        }

        public PartyInfoUpdateResViewModel GetPartyInfoUpdateResViewModel()
        {
            return new PartyInfoUpdateResViewModel();
        }

        public HouseInfoRelationShipDeleteResViewModel GetHouseInfoRelationShipDeleteResViewModel()
        {
            return new HouseInfoRelationShipDeleteResViewModel();
        }

        public IdentitySearchResidentResViewModel GetIdentitySearchResidentResViewModel()
        {
            return new IdentitySearchResidentResViewModel();
        }

        public ResidentIdentityRelationShipDeleteResViewModel GetResidentIdentityRelationShipDeleteResViewModel()
        {
            return new ResidentIdentityRelationShipDeleteResViewModel();
        }


        public UnderAgeSearchResViewModel GetUnderAgeSearchResViewModel()
        {
            return new UnderAgeSearchResViewModel();
        }

        public RightAgeSearchResViewModel GetRightAgeSearchResViewModel()
        {
            return new RightAgeSearchResViewModel();
        }

    }
}
