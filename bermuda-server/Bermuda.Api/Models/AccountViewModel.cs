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

    public class UserViewModel
    {
        public long id { get; set; }
        public string name { get; set; }
        public string sex { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public string type { get; set; }
        public string avatar_url { get; set; }
        public Int64 following_count { get; set; }
        public Int64 follower_count { get; set; }
        public decimal rate { get; set; }
        public int credit { get; set; }
    }
}
