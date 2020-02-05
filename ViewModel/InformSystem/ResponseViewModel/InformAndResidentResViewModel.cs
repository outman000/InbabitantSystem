using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicVIewModel;

namespace ViewModel.InformSystem.ResponseViewModel
{
    public class InformAndResidentResViewModel
    {
        /// <summary>
        /// 基础返回结果构造方法
        /// </summary>
        public InformAndResidentResViewModel()
        {
            baseViewModel = new BaseViewModel();

        }
        /// <summary>
        /// 添加成功的行数
        /// </summary>
        public int AddCount;
        /// <summary>
        /// 基础返回结果
        /// </summary>
        public BaseViewModel baseViewModel;
    }
}
