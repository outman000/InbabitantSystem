using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.MaintainSystem.MiddleViewModel;
using ViewModel.PublicVIewModel;

namespace ViewModel.MaintainSystem.ResponseViewModel
{
    public class CitySearchResViewModel
    {
        /// <summary>
        /// 基础返回结果构造方法
        /// </summary>
        public CitySearchResViewModel()
        {
            baseViewModel = new BaseViewModel();

        }
        /// <summary>
        /// 基础返回结果
        /// </summary>
        public BaseViewModel baseViewModel;

        public List<CitySearchMiddle> Data;
    }
}
