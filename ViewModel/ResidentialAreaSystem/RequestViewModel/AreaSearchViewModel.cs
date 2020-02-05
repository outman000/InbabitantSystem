using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicVIewModel;

namespace ViewModel.ResidentialAreaSystem.RequestViewModel
{
    public  class AreaSearchViewModel
    {

        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        AreaSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
        /// <summary>
        /// 小区Id
        /// </summary>
        public Guid? Id { get; set; }
        /// <summary>
        /// 小区名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 开发商
        /// </summary>
        public string Developers { get; set; }

        ///// <summary>
        ///// 物业
        ///// </summary>
        //public string Property { get; set; }

        /// <summary>
        /// 按建设时间查 开始时间
        /// </summary>
        public DateTime? ConstructionTimeStart { get; set; }
        /// <summary>
        /// 按建设时间查 结束时间
        /// </summary>
        public DateTime? ConstructionTimeEnd { get; set; }



    }
}
