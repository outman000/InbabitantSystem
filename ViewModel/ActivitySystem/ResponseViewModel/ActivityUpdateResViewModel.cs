using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicVIewModel;

namespace ViewModel.ActivitySystem.ResponseViewModel
{
    public class ActivityUpdateResViewModel
    {
        public ActivityUpdateResViewModel()
        {
            baseViewModel = new BaseViewModel();

        }
        /// <summary>
        /// 更新成功的行数
        /// </summary>
        public int AddCount;
        /// <summary>
        /// 基础返回结果
        /// </summary>
        public BaseViewModel baseViewModel;
    }
}
