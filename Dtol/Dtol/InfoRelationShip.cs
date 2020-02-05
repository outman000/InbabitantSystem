using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dtol.Dtol
{
    public class InfoRelationShip
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// 房屋id - 外键 （居民信息中 户主的id）
        /// </summary>
        public Guid? HouseInfoId { get; set; }
        /// <summary>
        /// 房屋信息
        /// </summary>
        public HouseInfo HouseInfo { get; set; }
        /// <summary>
        /// 人员信息 - 外键
        /// </summary>
        public Guid? ResidentInfoId { get; set; }
        /// <summary>
        /// 人员信息
        /// </summary>
        public ResidentInfo ResidentInfo { get; set; }
        /// <summary>
        /// 与户主关系
        /// </summary>
        public string RelationWithHousehold { get; set; }
    }
}
