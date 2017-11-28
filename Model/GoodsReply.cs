using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GoodsReply
    {
        public int      Id          { set; get; }
        public int      CmntId      { set; get; }
        public int      AimsId      { set; get; }
        public int      UserId      { set; get; }
        public string   Contents    { set; get; }
        public DateTime ReplyDate   { set; get; }
        public int      PraiseCount { set; get; }
    }
}
