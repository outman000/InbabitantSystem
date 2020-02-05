using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InformSystem.MiddleViewModel;
using ViewModel.PublicVIewModel;

namespace ViewModel.InformSystem.ResponseViewModel
{
    public class InformSearchByIdResViewModel
    {
        public InformSearchByIdResViewModel()
        {
            baseViewModel = new BaseViewModel();

        }
        /// <summary>
        /// 基础返回结果
        /// </summary>
        public BaseViewModel baseViewModel;

        public List<InformSearchByIdMiddle> Data;
    }
}
