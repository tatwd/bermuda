using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class NoticeReply
    {
        public long     Id          { set; get; }
        public long     CmntId      { set; get; }
        public long     AimsId      { set; get; }
        public long     UserId      { set; get; }
        public string   Contents    { set; get; }
        public DateTime ReplyDate   { set; get; }
        public int      PraiseCount { set; get; }
    }
}
