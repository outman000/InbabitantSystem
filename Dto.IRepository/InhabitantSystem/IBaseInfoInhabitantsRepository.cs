using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.InhabitantSystem.RequestViewModel;

namespace Dto.IRepository.InhabitantSystem
{
    public interface IBaseInfoInhabitantsRepository : IRepository<ResidentInfo>
    {
        List<BaseInfoInhabitantMiddle> getResidentByAllInfo(BaseInfoInhabitantViewModel baseInfoInhabitantViewModel);

        int getResidentByAllInfoCount(BaseInfoInhabitantViewModel baseInfoInhabitantViewModel);

        List<AddIdentitySearchResidentMiddle> getAddIdentitySearchResident(AddIdentitySearchResidentViewModel addIdentitySearchResidentViewModel);

        int getAddIdentitySearchResidentCount(AddIdentitySearchResidentViewModel addIdentitySearchResidentViewModel);
        //统计
        int getStatistics(StatisticsViewModel statisticsViewModel);

        List<ResidentInfoSearchMiddle> getResidentInfoSearchResident(ResidentInfoSearchViewModel residentInfoSearchViewModel);

        int getResidentInfoSearchResidentCount(ResidentInfoSearchViewModel residentInfoSearchViewModel);

        List<ByHouseInfoSearchResidentMiddle> getByHouseInfoSearchResident(ByHouseInfoSearchResidentViewModel byHouseInfoSearchResidentViewModel);

        ResidentInfo GetById2(Guid id);

        List<IdentitySearchResidentMiddle> getIdentitySearchResident(IdentitySearchResidentViewModel identitySearchResidentViewModel);

        int getIdentitySearchResidentCount(IdentitySearchResidentViewModel identitySearchResidentViewModel);

    }
}
