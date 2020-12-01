using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroService.AuthenticationCenter.Enums;

namespace MicroService.AuthenticationCenter.Models
{
    public class UserModel
    {
        public int UserId { set; get; }

        /// <summary>
        /// 用户所属商家ID
        /// </summary>
        public int MerchantId { set; get; }

        public string SubjectId { set; get; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { set; get; }

        /// <summary>
        /// 用户显示名称
        /// </summary>
        public string DisplayName { set; get; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password { set; get; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public EnumUserRole Role { set; get; }
    }
}
