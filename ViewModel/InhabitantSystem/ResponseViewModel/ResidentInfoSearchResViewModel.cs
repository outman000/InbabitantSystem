using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.PublicVIewModel;

namespace ViewModel.InhabitantSystem.ResponseViewModel
{
    public class ResidentInfoSearchResViewModel
    {
        

        /// <summary>
        /// 基础返回结果构造方法
        /// </summary>
        public ResidentInfoSearchResViewModel()
        {
            baseViewModel = new BaseViewModel();

        }
        public BaseViewModel baseViewModel;
        public int TotalCount;
        public List<ResidentInfoSearchMiddle> Data;
    }
}
