using Dtol.Dtol;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BuildingSystem.MiddleViewModel
{
    public class BuildingSearchMiddleViewModel
    {
        /// <summary>
        /// 楼宇id
        /// </summary>
        
        public Guid? Id { get; set; } 
        /// <summary>
        /// 小区Id - 外键
        /// </summary>
        public Guid? AreaId { get; set; }
        /// <summary>
        /// 小区信息
        /// </summary>
        public ResidentialArea AreaInfo { get; set; }
        /// <summary>
        /// 小区名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 楼号
        /// </summary>
        public int? BuildingNo { get; set; }
        /// <summary>
        /// 单元号
        /// </summary>
        public int? UnitNo { get; set; }
        /// <summary>
        /// 楼层数
        /// </summary>
        public int? FloorCount { get; set; }
        /// <summary>
        /// 电梯数
        /// </summary>
        public int? ElevatorCount { get; set; }
        /// <summary>
        /// 每层户数
        /// </summary>
        public int? HouseCount { get; set; }
        /// <summary>
        /// 建设时间
        /// </summary>
        public DateTime? ConstructionTime { get; set; }
        /// <summary>
        /// 入住时间
        /// </summary>
        public DateTime? CheckinTime { get; set; }
        /// <summary>
        /// 楼宇性质
        /// </summary>
        public string BuildingNature { get; set; }
        /// <summary>
        /// 地下层数
        /// </summary>
        public int? UndergroundCount { get; set; }

        /// <summary>
        /// 状态  0-删除 1-有效
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddTime { get; set; }
    }
}
