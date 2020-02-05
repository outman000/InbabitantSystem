using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicVIewModel;

namespace ViewModel.InformSystem.ResponseViewModel
{
    public class InformUpdateResViewModel
    {
        public InformUpdateResViewModel()
        {
            baseViewModel = new BaseViewModel();

        }
        /// <summary>
        /// 更新成功的行数
        /// </summary>
        public int UpdateCount;
        /// <summary>
        /// 基础返回结果
        /// </summary>
        public BaseViewModel baseViewModel;

    }
}
