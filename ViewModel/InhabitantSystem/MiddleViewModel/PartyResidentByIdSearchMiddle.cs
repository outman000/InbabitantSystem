using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.InhabitantSystem.MiddleViewModel
{
    public class PartyResidentByIdSearchMiddle
    {
        /// <summary>
        /// 居民信息id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 政治面貌
        /// </summary>
        public string Politics { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdNumber { get; set; }
        /// <summary>
        /// 文化程度
        /// </summary>
        public string Education { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string Minority { get; set; }
        /// <summary>
        /// 党员信息ID
        /// </summary>
        public Guid PartId { get; set; }
        /// <summary>
        /// 入党时间
        /// </summary>
        public DateTime? JoinPartyTime { get; set; }
        /// <summary>
        /// 党内职务
        /// </summary>
        public string PartyJob { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Comment { get; set; }
    }
}
