using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dtol.Dtol
{
    public class HouseInfo
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// 户主姓名
        /// </summary>
        public string HouseHolder { get; set; }
        /// <summary>
        /// 户主身份证号
        /// </summary>
        public string HouseHolderIdNo { get; set; }


        /// <summary>
        /// 户籍地
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 县
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// 户籍状况
        /// </summary>
        public string Register { get; set; }

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
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddTime { get; set; }
    }
}
