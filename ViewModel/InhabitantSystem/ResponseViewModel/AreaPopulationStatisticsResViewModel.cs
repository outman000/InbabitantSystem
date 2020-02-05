using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.PublicVIewModel;

namespace ViewModel.InhabitantSystem.ResponseViewModel
{
    public class AreaPopulationStatisticsResViewModel
    {
        /// <summary>
        /// 基础返回结果构造方法
        /// </summary>
        public AreaPopulationStatisticsResViewModel()
        {
            baseViewModel = new BaseViewModel();

        }
        /// <summary>
        /// 基础返回结果
        /// </summary>
        public BaseViewModel baseViewModel;

        public List<AreaPopulationStatisticsMiddle> Data;
    }
}
