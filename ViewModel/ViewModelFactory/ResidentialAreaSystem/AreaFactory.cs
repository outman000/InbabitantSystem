using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.IViewModelFactory.InhabitantSystem;
using ViewModel.ResidentialAreaSystem.ReponseViewModel;
using ViewModel.ResidentialAreaSystem.RequestViewModel;

namespace ViewModel.ViewModelFactory.InhabitantSystem
{
    /// <summary>
    /// 实现小区创建实例工厂
    /// </summary>
    public class AreaFactory : IAreaFactory
    {
        /// <summary>
        /// 获取添加结果模型视图
        /// </summary>
        /// <returns></returns>
        public AreaAddResponseViewModel GetAreaAddResponseViewModel()
        {
            return new AreaAddResponseViewModel();
        }
        /// <summary>
        /// 获取小区查询结果模型视图
        /// </summary>
        /// <returns></returns>
        public AreaSearchResModel GetAreaSearchResponseViewModel()
        {
            return new AreaSearchResModel();
        }
        /// <summary>
        /// 更新小区结果模型视图
        /// </summary>
        /// <returns></returns>
        public AreaUpdateResViewModel GetAreaUpdateResponseViewModel()
        {
            return new AreaUpdateResViewModel();
        }

        

        
    }
}
