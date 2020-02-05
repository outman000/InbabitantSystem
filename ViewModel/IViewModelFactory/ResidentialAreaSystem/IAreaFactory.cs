using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.ResidentialAreaSystem.ReponseViewModel;
using ViewModel.ResidentialAreaSystem.RequestViewModel;

namespace ViewModel.IViewModelFactory.InhabitantSystem
{
    /// <summary>
    /// 小区视图模型工厂
    /// </summary>
    public interface IAreaFactory
    {
        /// <summary>
        /// 获取添加小区结果实例
        /// </summary>
        /// <returns></returns>
        AreaAddResponseViewModel GetAreaAddResponseViewModel();
        /// <summary>
        /// 获取查询小区结果实例
        /// </summary>
        /// <returns></returns>
        AreaSearchResModel GetAreaSearchResponseViewModel();
        /// <summary>
        /// 更新小区结果实例
        /// </summary>
        /// <returns></returns>
        AreaUpdateResViewModel GetAreaUpdateResponseViewModel();
    }
}
