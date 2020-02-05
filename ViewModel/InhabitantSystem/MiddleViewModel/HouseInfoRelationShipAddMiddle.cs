using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.InhabitantSystem.MiddleViewModel
{
    public class HouseInfoRelationShipAddMiddle
    {
        /// <summary>
        /// id
        /// </summary>
        public Guid Id { get; set; } 
        /// <summary>
        /// 房屋id - 外键 
        /// </summary>
        public Guid? HouseInfoId { get; set; }
       
        /// <summary>
        /// 人员信息 - 外键
        /// </summary>
        public Guid? ResidentInfoId { get; set; }
        /// <summary>
        /// 与户主关系
        /// </summary>
        public string RelationWithHousehold { get; set; }

    }
}
