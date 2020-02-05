using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.BuildingSystem.ReponseViewModel;

namespace ViewModel.IViewModelFactory.IBuildingSystem
{
    public interface IBuildingFactory
    {
        /// <summary>
        /// 获取添加楼宇结果实例
        /// </summary>
        /// <returns></returns>
        BuildingAddResViewModel GetBuildingAddResViewModel();
        /// <summary>
        /// 获取查询楼宇结果
        /// </summary>
        /// <returns></returns>
        BuildingSearchResViewModel GetBuildingSearchResViewModel();
        /// <summary>
        /// 更新楼宇结果
        /// </summary>
        /// <returns></returns>
        BuildingUpdateResViewModel GetBuildingUpdateResViewModel();
    }
}
