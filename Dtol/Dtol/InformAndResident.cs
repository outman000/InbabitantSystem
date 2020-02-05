using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dtol.Dtol
{
    public class InformAndResident
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// 通知Id
        /// </summary>
        public Guid? InformId { get; set; }
        /// <summary>
        /// 通知具体信息
        /// </summary>
        public Inform Inform { get; set; }
        /// <summary>
        /// 居民Id
        /// </summary>
        public Guid? residentInfoId { get; set; }
        /// <summary>
        /// 居民具体信息
        /// </summary>
        public ResidentInfo residentInfo { get; set; }

    }
}
