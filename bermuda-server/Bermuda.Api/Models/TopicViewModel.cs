namespace Bermuda.Api.Models
{
    using System;

    public class TopicViewModel
    {
        public Int64 id { get; set; }
        public Int64 user_id { get; set; }
        public string name { get; set; }
        public string detail { get; set; }
        public Int64 join_count { get; set; }
        public DateTime create_date { get; set; }
        public string img_url { get; set; }
    }
}
