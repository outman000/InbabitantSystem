using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.PublicVIewModel;

namespace ViewModel.InhabitantSystem.ResponseViewModel
{
    public class RightAgeSearchResViewModel
    {
        /// <summary>
        /// 基础返回结果构造方法
        /// </summary>
        public RightAgeSearchResViewModel()
        {
            baseViewModel = new BaseViewModel();

        }
        /// <summary>
        /// 基础返回结果
        /// </summary>
        public BaseViewModel baseViewModel;

        public List<RightAgeSearchMiddle> Data;

        
    }
}
