using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bmd.App.Models
{
    public class AccountViewModel
    {
    }

    public class SignInViewModel
    {
        [Required(ErrorMessage = "请输入用户名"),
        StringLength(200, MinimumLength = 3, 
            ErrorMessage = "长度不少于 3")]
        public string Name { get; set; }

        [Required(ErrorMessage = "请输入密码")]
        [StringLength(16, MinimumLength = 6, 
            ErrorMessage = "请输入 6~16 位密码")]
        [DataType(DataType.Password)]
        public string Pwd { get; set; }

        public Boolean RememberMe { get; set; }
    }

    public class SignUpViewModel
    {
        [Required(ErrorMessage = "请输入用户名"),
        StringLength(200, MinimumLength = 3,
            ErrorMessage = "长度不少于 3")]
        public string Name { get; set; }

        [Required(ErrorMessage = "请输入邮箱"),
        RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "邮箱格式不对")]
        public string Email { get; set; }

        [Required(ErrorMessage = "请输入密码"),
        DataType(DataType.Password),
        StringLength(16, MinimumLength = 6,
            ErrorMessage = "请输入 6~16 位密码")]
        public string Pwd { get; set; }

        [Required(ErrorMessage = "请确认密码"),
        DataType(DataType.Password),
        Compare("Pwd", 
            ErrorMessage = "密码和确认密码不匹配")]
        public string ConfirmPwd { get; set; }
    }

}