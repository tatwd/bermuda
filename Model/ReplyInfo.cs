using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class ReplyInfo
    {
        public int ReplyInfoId { get; set; }
        public int CmntId { get; set; }
        public int ReplyAuthor { get; set; }
        public string ReplyContent { get; set; }
        public DateTime ReplyDate { get; set; }
        public int PraiseCount { get; set; }
    }
}
