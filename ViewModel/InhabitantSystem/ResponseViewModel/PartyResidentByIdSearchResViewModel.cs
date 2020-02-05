using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InhabitantSystem.MiddleViewModel;
using ViewModel.PublicVIewModel;

namespace ViewModel.InhabitantSystem.ResponseViewModel
{
    public class PartyResidentByIdSearchResViewModel
    {
        /// <summary>
        /// 基础返回结果构造方法
        /// </summary>
        public PartyResidentByIdSearchResViewModel()
        {
            baseViewModel = new BaseViewModel();

        }
        /// <summary>
        /// 基础返回结果
        /// </summary>
        public BaseViewModel baseViewModel;

        public PartyResidentByIdSearchMiddle Data;
    }
}
