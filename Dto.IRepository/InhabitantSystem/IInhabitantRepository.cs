using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.InhabitantSystem.RequestViewModel;
using ViewModel.InhabitantSystem.ResponseViewModel;

namespace Dto.IRepository.InhabitantSystem
{
    public interface IInhabitantRepository :IRepository<ResidentInfo>
    {
        IQueryable<ResidentInfo> InhabitantSerachByWhere(InhabitantSearchViewModel inhabitantSearchViewModel);
        void AddInfo(List<ResidentInfo> obj);

        void UpdateInfo(List<ResidentInfo> obj);

        ResidentInfo InhabitantSerachByIdNoWhere(string IdNo);

        /// <summary>
        /// 查询党员的居民信息
        /// </summary>
        /// <param name="partyResidentSearchViewModel"></param>
        /// <returns></returns>
        List<PartyResidentSearchMiddle> getPartResidentSearch(PartyResidentSearchViewModel partyResidentSearchViewModel);
        int getPartResidentSearchCount(PartyResidentSearchViewModel partyResidentSearchViewModel);
        /// <summary>
        /// 根据id查询党员的居民信息
        /// </summary>
        /// <param name="partyResidentByIdSearchViewModel"></param>
        /// <returns></returns>
        PartyResidentByIdSearchMiddle getPartResidentByIdSearch(PartyResidentByIdSearchViewModel partyResidentByIdSearchViewModel);

        /// <summary>
        /// 查询未成年人
        /// </summary>
        /// <param name="underAgerSearchViewModel"></param>
        /// <returns></returns>
        List<UnderAgeSearchMiddle> GetUnderAgeSearch(UnderAgerSearchViewModel underAgerSearchViewModel);
        /// <summary>
        /// 查询适龄人员
        /// </summary>
        /// <param name="rightAgeSearchViewModel"></param>
        /// <returns></returns>
        List<RightAgeSearchMiddle> GetRightAgeSearch(RightAgeSearchViewModel rightAgeSearchViewModel);


    }
}
