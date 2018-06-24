using System;
using System.Collections.Generic;
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
        public string brief_text { get; set; }
        public long cmnt_count { get; set; }
        public long star_count { get; set; }
        public long praise_count { get; set; }
        public DateTime created_at { get; set; }
    }

    public class NewCurrentViewModel
    {
        [Required, MaxLength(50)]
        public string title { get; set; }

        [Required]
        public string text { get; set; }

        [Required, MaxLength(280)]
        public string brief_text { get; set; }

        [Required]
        public Int64[] topic_ids = new Int64[3];
    }

    public class CurrentSearchModel
    {
        public long id { get; set; }
        //public UserViewModel user { get; set; }
        public string title { get; set; }
        //public string text { get; set; }
        public string brief_text { get; set; }
        public long cmnt_count { get; set; }
        public long star_count { get; set; }
        public long praise_count { get; set; }
        public DateTime created_at { get; set; }
    }

    public class CurrentCmntViewModel
    {
        public Int64 id { get; set; }
        public SimpleUserViewModel user { get; set; }
        public string text { get; set; }
        public Int64 praise_count { get; set; }
        public Int64 reply_count { get; set; }
        public DateTime created_at { get; set; }
        public IList<CurrentCmntReplyViewModel> replies { get; set; }
    }

    public class CurrentCmntReplyViewModel
    {
        public Int64 id { get; set; }
        public Int64 cmnt_id { get; set; }
        //public Int64 aims_id { get; set; }
        public SimpleUserViewModel user { get; set; }
        public SimpleUserViewModel aims_user { get; set; }
        public string text { get; set; }
        public Int64 praise_count { get; set; }
        public DateTime created_at { get; set; }
    }
}
