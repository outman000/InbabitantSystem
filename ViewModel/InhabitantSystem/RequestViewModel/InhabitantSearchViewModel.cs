using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.InhabitantSystem.RequestViewModel
{
    public class InhabitantSearchViewModel
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
        /// 民族
        /// </summary>
        public string Minority { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 婚姻状况
        /// </summary>
        public string Married { get; set; }
        /// <summary>
        /// 政治面貌
        /// </summary>
        public string Politics { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdNumber { get; set; }
        /// <summary>
        /// 工作单位
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// 户籍地
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 户籍状况
        /// </summary>
        public string Register { get; set; }
        
        /// <summary>
        /// 文化程度
        /// </summary>
        public string Education { get; set; }
        /// <summary>
        /// 与户主关系
        /// </summary>
        public string RelationWithHousehold { get; set; }
        
        /// <summary>
        /// 宗教信仰
        /// </summary>
        public string ReligiousBelief { get; set; }
        /// <summary>
        /// 职业
        /// </summary>
        public string Job { get; set; }
        /// <summary>
        /// 照片id
        /// </summary>
        public string PhotoId { get; set; }
        /// <summary>
        /// 居民身份状态    0-军人 1-党员 
        /// </summary>
        //public string ResidentIdentityStatus { get; set; }
        /// <summary>
        /// 状态  0-删除 1-有效
        /// </summary>
        public string Status { get; set; }
    }
}
