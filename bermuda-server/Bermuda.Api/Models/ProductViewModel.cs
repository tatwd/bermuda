using System;

namespace Bermuda.Api.Models
{
    public class ProductViewModel
    {
        public long id { get; set; }
        //public long user_id { get; set; }
        public UserViewModel user { get; set; }
        public string title { get; set; }
        public string category { get; set; }
        public string tag { get; set; }
        public decimal price { get; set; }
        public int inventory { get; set; }
        public string img_url { get; set; }
        public string tale { get; set; }
        public DateTime created_at { get; set; }
    }
}
