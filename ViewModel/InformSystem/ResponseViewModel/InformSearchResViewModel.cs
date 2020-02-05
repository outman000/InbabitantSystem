using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InformSystem.MiddleViewModel;
using ViewModel.PublicVIewModel;

namespace ViewModel.InformSystem.ResponseViewModel
{
    public class InformSearchResViewModel
    {
        /// <summary>
        /// 基础返回结果构造方法
        /// </summary>
        public InformSearchResViewModel()
        {
            baseViewModel = new BaseViewModel();

        }
        /// <summary>
        /// 基础返回结果
        /// </summary>
        public BaseViewModel baseViewModel;
        public int TotalCount;
        public List<InformSearchMiddle> Data;
    }
}
