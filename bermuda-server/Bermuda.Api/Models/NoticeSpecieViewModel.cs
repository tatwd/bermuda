using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bermuda.Api.Models
{
    public class NoticeSpecieViewModel
    {
        public Int64 id { get; set; }
        public String name { get; set; }
        public String img_url { get; set; }
        public Int64 notice_count { get; set; }
    }
}
