using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.ResidentialAreaSystem.MiddleViewModel
{
    public class AreaSearchMiddle
    {
        /// <summary>
        /// 小区id
        /// </summary>

        public Guid Id { get; set; }

        /// <summary>
        /// 小区名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 开发商
        /// </summary>
        public string Developers { get; set; }

        /// <summary>
        /// 物业
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// 建设时间
        /// </summary>
        public DateTime ConstructionTime { get; set; }

        /// <summary>
        /// 物业费
        /// </summary>
        public double PropertyFee { get; set; }

        /// <summary>
        /// 物业联系人
        /// </summary>
        public string PropertyContacts { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public int Telephone { get; set; }

        /// <summary>
        /// 建筑面积
        /// </summary>
        public double BuiltUpArea { get; set; }

        /// <summary>
        /// 车位数量（上面）
        /// </summary>
        public int ParkingSpacesAbove { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ParkingSpacesBelow { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 东至
        /// </summary>
        public string East { get; set; }

        /// <summary>
        /// 南至
        /// </summary>
        public string South { get; set; }

        /// <summary>
        /// 西至
        /// </summary>
        public string West { get; set; }

        /// <summary>
        /// 北至
        /// </summary>
        public string North { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddTime { get; set; }

    }
}
