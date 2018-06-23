using System;
using System.ComponentModel.DataAnnotations;

namespace Bermuda.Api.Models
{
    public class CurrentViewModel
    {
        public long id { get; set; }
        //public long user_id { get; set; }
        public UserViewModel user { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public long cmnt_count { get; set; }
        public long star_count { get; set; }
        public long praise_count { get; set; }
        public DateTime created_at { get; set; }
    }

    public class NewCurrentViewModel
    {
        [Required]
        public string title { get; set; }

        [Required]
        public string text { get; set; }

        [Required]
        public Int64[] topic_ids = new Int64[3];
    }
}
