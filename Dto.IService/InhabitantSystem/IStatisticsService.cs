using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.InhabitantSystem.RequestViewModel;

namespace Dto.IService.InhabitantSystem
{
    public interface IStatisticsService
    {
        /// <summary>
        /// 获取每个小区人数
        /// </summary>
        /// <returns></returns>
        List<AreaPopulationStatisticsMiddle> GetAreaPopulation(List<StatisticsViewModel> statisticsViewModel);
        /// <summary>
        /// 获取年龄段人数
        /// </summary>
        /// <returns></returns>
        List<AgeStatisticsMiddle> GetAgeCount();
        /// <summary>
        /// 获取性别人数
        /// </summary>
        /// <returns></returns>
        List<GenderStatisticsMiddle> GetGenderCount();




    }
}
