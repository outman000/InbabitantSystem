using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicVIewModel;

namespace ViewModel.InformSystem.ResponseViewModel
{
    public class InformAddResViewModel
    {
        /// <summary>
        /// 基础返回结果构造方法
        /// </summary>
        public InformAddResViewModel()
        {
            baseViewModel = new BaseViewModel();

        }
        /// <summary>
        /// 添加成功的行数
        /// </summary>
        public int AddCount;
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id;
        /// <summary>
        /// 基础返回结果
        /// </summary>
        public BaseViewModel baseViewModel;
    }
}
