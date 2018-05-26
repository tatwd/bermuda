using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bermuda.Api.Models
{
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
        public Int64 found_count { get; set; }
        public Int64 lost_count { get; set; }
        public Int64 help_count { get; set; }
        public decimal rating { get; set; }
        public int credit { get; set; }
        public DateTime created_at { get; set; }
    }
}
