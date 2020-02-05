using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.ActivitySystem.MiddleViewModel;
using ViewModel.PublicVIewModel;

namespace ViewModel.ActivitySystem.ResponseViewModel
{
    public class ActivitySearchResViewModel
    {
        /// <summary>
        /// 基础返回结果构造方法
        /// </summary>
        public ActivitySearchResViewModel()
        {
            baseViewModel = new BaseViewModel();

        }
        /// <summary>
        /// 基础返回结果
        /// </summary>
        public BaseViewModel baseViewModel;
        public int TotalCount;
        public List<ActivitySearchMiddle> Data;
    }
}
