using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.PublicVIewModel;

namespace ViewModel.InhabitantSystem.ResponseViewModel
{
    public class BaseInfoInhabitantsResViewModel
    {
        /// <summary>
        /// 基础返回结果构造方法
        /// </summary>
        public BaseInfoInhabitantsResViewModel()
        {
            baseViewModel = new BaseViewModel();

        }
        /// <summary>
        /// 基础返回结果
        /// </summary>
        public BaseViewModel baseViewModel;
        public int TotalCount;
        public List<BaseInfoInhabitantMiddle> Data;

        
    }
}
