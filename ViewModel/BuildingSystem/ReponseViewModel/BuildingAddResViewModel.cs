using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicVIewModel;

namespace ViewModel.BuildingSystem.ReponseViewModel
{
    public class BuildingAddResViewModel
    {
        /// <summary>
        /// 基础返回结果构造方法
        /// </summary>
        public BuildingAddResViewModel()
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
