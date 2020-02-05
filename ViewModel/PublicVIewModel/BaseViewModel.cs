using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.PublicVIewModel
{
    /// <summary>
    /// 返回结果基础数据
    /// </summary>
    public  class BaseViewModel
    {
       /// <summary>
       /// 是否成功
       /// </summary>
        public bool IsSuccess;
        /// <summary>
        /// 状态码
        /// </summary>
        public int ResponseCode;
        /// <summary>
        /// 消息
        /// </summary>
        public string Message;
        
    }
}
