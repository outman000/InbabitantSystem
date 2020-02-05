using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicVIewModel;

namespace ViewModel.InhabitantSystem.RequestViewModel
{
    public class IdentitySearchResidentViewModel
    {

        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        IdentitySearchResidentViewModel()
        {
            pageViewModel = new PageViewModel();
        }
        /// <summary>
        /// 小区
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 身份名称
        /// </summary>
        public string IdentityName { get; set; }
    }
}
