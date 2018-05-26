using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bermuda.Api.Models
{
    public class NoticeViewModel
    {
        public Int64 id { get; set; }
        public Int64 user_id { get; set; }
        public string user_name { get; set; }
        public Int64 specie_id { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public string place { get; set; }
        public string full_place { get; set; }
        public string event_time_desc { get; set; }
        public string img_url { get; set; }
        public string contact_way { get; set; }
        public string detail { get; set; }
        public DateTime created_at { get; set; }
        public Int64 cmnt_count { get; set; }
        public Int64 trace_count { get; set; }
        public byte is_solved { get; set; }
        public UserViewModel user { get; set; }
    }
}
