using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.MaintainSystem.MiddleViewModel;
using ViewModel.PublicVIewModel;

namespace ViewModel.MaintainSystem.ResponseViewModel
{
    public class NationSearchResViewModel
    {
        /// <summary>
        /// 基础返回结果构造方法
        /// </summary>
        public NationSearchResViewModel()
        {
            baseViewModel = new BaseViewModel();

        }
        /// <summary>
        /// 基础返回结果
        /// </summary>
        public BaseViewModel baseViewModel;

        public List<NationSearchMiddle> Data;
    }
}
