using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dtol.Dtol
{
    public class UserInfo
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }

        public string Status { get; set; }

        public DateTime? AddTime { get; set; }

    }
}
