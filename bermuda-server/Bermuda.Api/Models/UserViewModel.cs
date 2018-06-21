using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bermuda.Api.Models
{
    public class BaseUserViewModel
    {
        public Int64 id { get; set; }
        public bool is_following = false;
    }

    public class UserViewModel : BaseUserViewModel
    {
        public string name { get; set; }
        public string sex { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public string type { get; set; }
        public string avatar_url { get; set; }
        public Int64 following_count { get; set; }
        public Int64 follower_count { get; set; }
        public Int64 found_count { get; set; }
        public Int64 lost_count { get; set; }
        public Int64 help_count { get; set; }
        public decimal rating { get; set; }
        public int credit { get; set; }
        public DateTime created_at { get; set; }
    }

    public class UserSearchModel : BaseUserViewModel
    {
        public string name { get; set; }
        public string avatar_url { get; set; }
        public Int64 following_count { get; set; }
        public Int64 follower_count { get; set; }
        public Int64 found_count { get; set; }
        public Int64 lost_count { get; set; }
        public Int64 help_count { get; set; }
    }

    public class UserFollowingViewModel
    {
        [Required]
        public Int64 user_id { get; set; }

        [Required]
        public Int64 following_id { get; set; }
    }
}
