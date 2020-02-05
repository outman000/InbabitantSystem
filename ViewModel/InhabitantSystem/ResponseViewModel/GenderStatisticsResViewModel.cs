using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.PublicVIewModel;

namespace ViewModel.InhabitantSystem.ResponseViewModel
{
    public class GenderStatisticsResViewModel
    {
        /// <summary>
        /// 基础返回结果构造方法
        /// </summary>
        public GenderStatisticsResViewModel()
        {
            baseViewModel = new BaseViewModel();

        }
        /// <summary>
        /// 基础返回结果
        /// </summary>
        public BaseViewModel baseViewModel;

        public List<GenderStatisticsMiddle> Data;
    }
}
