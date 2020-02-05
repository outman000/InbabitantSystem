using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicVIewModel;

namespace ViewModel.InformSystem.RequestViewModel
{
    public class InformSearchByIdViewModel
    {

        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        InformSearchByIdViewModel()
        {
            pageViewModel = new PageViewModel();
        }
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; } 
    }
}
