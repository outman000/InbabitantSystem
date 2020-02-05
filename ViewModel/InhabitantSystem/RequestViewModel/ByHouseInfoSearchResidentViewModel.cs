using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.InhabitantSystem.RequestViewModel
{
    public class ByHouseInfoSearchResidentViewModel
    {
        /// <summary>
        /// 小区名称
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// 楼号
        /// </summary>
        public int? BuildingNo { get; set; }
        /// <summary>
        /// 单元号
        /// </summary>
        public int? UnitNo { get; set; }
        /// <summary>
        /// 门牌号
        /// </summary>
        public string HouseNo { get; set; }
    }
}
