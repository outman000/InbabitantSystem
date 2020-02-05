using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Dtol.Dtol
{
    public class ResidentRelationShip
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// 人员信息Id
        /// </summary>
        public Guid? ResidentInfoId { get; set; }
        /// <summary>
        /// 人员信息
        /// </summary>
        public ResidentInfo ResidentInfo { get; set; }
        /// <summary>
        /// 身份Id
        /// </summary>
        public Guid? ResidentIdentityId { get; set; }
        /// <summary>
        /// 身份信息
        /// </summary>
        public ResidentIdentity ResidentIdentity { get; set; }

    }
}
