using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bermuda.Model
{
    public class NoticeReply
    {
        public Int64    Id          { set; get; }
        public Int64    CmntId      { set; get; }
        public Int64    AimsId      { set; get; }
        public Int64    UserId      { set; get; }
        public String   Contents    { set; get; }
        public DateTime ReplyDate   { set; get; }
        public Int32    PraiseCount { set; get; }
    }
}
