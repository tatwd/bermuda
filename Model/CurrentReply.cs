using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CurrentReply
    {
        public int      Id          { set; get; }
        public int      CurrentId   { set; get; }
        public int      AimsId      { set; get; }
        public int      UserId      { set; get; }
        public string   Contents    { set; get; }
        public DateTime ReplyDate   { set; get; }
        public int      PraiseCount { set; get; }
    }
}
