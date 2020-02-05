using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dtol.Dtol
{
    public class PartyInfo
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// 居民id
        /// </summary>
        public Guid? ResidentId { get; set; }
        /// <summary>
        /// 居民身份证号
        /// </summary>
        public string IdNumber { get; set; }
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
