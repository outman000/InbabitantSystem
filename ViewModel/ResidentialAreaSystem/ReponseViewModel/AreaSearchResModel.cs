using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicVIewModel;
using ViewModel.ResidentialAreaSystem.MiddleViewModel;

namespace ViewModel.ResidentialAreaSystem.ReponseViewModel
{
    /// <summary>
    /// 查询结果
    /// </summary>
    public class AreaSearchResModel
    {
        /// <summary>
        /// 基础返回结果构造方法
        /// </summary>
        public AreaSearchResModel()
        {
            baseViewModel = new BaseViewModel();

        }
        /// <summary>
        /// 基础返回结果
        /// </summary>
        public BaseViewModel baseViewModel;

        public int TotalCount;
        /// <summary>
        /// 返回结果
        /// </summary>
        public   List<AreaSearchMiddle> Data;

    }
}
