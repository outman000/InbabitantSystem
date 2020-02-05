using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BuildingSystem.MiddleViewModel;
using ViewModel.PublicVIewModel;

namespace ViewModel.BuildingSystem.ReponseViewModel
{
    public class BuildingSearchResViewModel
    {
        /// <summary>
        /// 基础返回结果构造方法
        /// </summary>
        public BuildingSearchResViewModel()
        {
            baseViewModel = new BaseViewModel();

        }
        /// <summary>
        /// 基础返回结果
        /// </summary>
        public BaseViewModel baseViewModel;
        /// <summary>
        /// 总数
        /// </summary>
        public int TotalCount;
        /// <summary>
        /// 楼栋数
        /// </summary>
        public int BuildingNoCount;
        /// <summary>
        /// 单元数
        /// </summary>
        public int UnitNoCount;
        /// <summary>
        /// 住户数
        /// </summary>
        public int HouseNoCount;

        public List<BuildingSearchMiddleViewModel> Data;

    }
}
