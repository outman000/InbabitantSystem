using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.RequestViewModel;
using ViewModel.ResidentialAreaSystem.MiddleViewModel;
using ViewModel.ResidentialAreaSystem.RequestViewModel;

namespace Dto.IService.ResidentialAreaSystem
{
    public interface IResidentialAreaService
    {
        int addArea(AreaAddViewModel areaAddViewModel);
        List<AreaSearchMiddle> Area_Search(AreaSearchViewModel areaSearchViewModel);
        int Area_SearchCount(AreaSearchViewModel areaSearchViewModel);
        int Area_Update(AreaUpdateViewModel areaUpdateViewModel);
        /// <summary>
        /// 获取所有小区
        /// </summary>
        /// <returns></returns>
        List<StatisticsViewModel> GetAllArea();
    }
}
