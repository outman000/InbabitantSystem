using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InformSystem.MiddleViewModel;
using ViewModel.InformSystem.RequestViewModel;
using ViewModel.InformSystem.ResponseViewModel;

namespace Dto.IService.InformSystem
{
    public interface IInformService
    {
        InformAddResViewModel AddInform(InformAddViewModel informAddViewModel);
        int AddInformAndResident(InformAndResidentViewModel informAndResidentViewModel);

        List<InformSearchMiddle> Inform_Search(InformSearchViewModel informSearchViewModel);
        int Inform_SearchCount(InformSearchViewModel informSearchViewModel);


        List<InformSearchByIdMiddle> Inform_Search_ById(InformSearchByIdViewModel informSearchByIdViewModel);

        int UpdateInform(InformUpdateViewModel informUpdateViewModel);
    }
}
