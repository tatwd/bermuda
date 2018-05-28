using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bermuda.Api.Models
{
    public class AccountViewModel
    {
    }

    public class RegisterViewModel
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        //[Required]
        //[Compare("password", ErrorMessage = "密码不一致")]
        //public string confirm_password { get; set; }
    }

    public class LoginViewModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
