using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.InhabitantSystem.MiddleViewModel
{
    public class HouseInfoUpdateMiddle
    {
        /// <summary>
        /// Id
        /// </summary>

        public Guid Id { get; set; }
        /// <summary>
        /// 户主姓名
        /// </summary>
        public string HouseHolder { get; set; }
        /// <summary>
        /// 户主身份证号
        /// </summary>
        public string HouseHolderIdNo { get; set; }
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

        /// <summary>
        /// 状态  0-删除 1-有效
        /// </summary>
        public string Status { get; set; }
    }
}
