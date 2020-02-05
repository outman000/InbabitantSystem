using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.InformSystem.MiddleViewModel;

namespace ViewModel.InformSystem.RequestViewModel
{
    public class InformAndResidentViewModel
    {
        /// <summary>
        /// 短息内容
        /// </summary>
        public string content { get; set; }
        public InformUpdateViewModel informUpdateViewModel { get; set; }
        public List<InformAndResidentMiddle> informAndResidentMiddles { get; set; }
        
    }
}
