using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dtol.Dtol
{
    public class ResidentIdentity
    {
        /// <summary>
        /// 身份id
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// 身份名称
        /// </summary>
        public string IdentityName { get; set; }
        /// <summary>
        /// 关系Id
        /// </summary>
        public Guid FormId { get; set; }
        /// <summary>
        /// 状态  0-删除 1-有效
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }













    }
}
