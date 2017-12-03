using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class NoticeCmnt
    {
        public long     Id          { set; get; }
        public long     NoticeId    { set; get; }
        public long     UserId      { set; get; }
        public string   Contents    { set; get; }
        public DateTime CmntDate    { set; get; }
        public int      ReplyCount  { set; get; }
        public int      PraiseCount { set; get; }

    }
}
