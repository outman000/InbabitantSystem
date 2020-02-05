using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicVIewModel;

namespace ViewModel.InhabitantSystem.RequestViewModel
{
    public class PartyResidentSearchViewModel
    {
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        PartyResidentSearchViewModel()
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
        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

    }
}
