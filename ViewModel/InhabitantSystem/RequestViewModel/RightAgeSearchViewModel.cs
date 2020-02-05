using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicVIewModel;

namespace ViewModel.InhabitantSystem.RequestViewModel
{
    public class RightAgeSearchViewModel
    {
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        RightAgeSearchViewModel()
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
        

        
    }
}
