using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bermuda.Model
{
    public class NoticeCmnt
    {
        public Int64    Id          { set; get; }
        public Int64    NoticeId    { set; get; }
        public Int64    UserId      { set; get; }
        public String   Contents    { set; get; }
        public DateTime CmntDate    { set; get; }
        public Int32    ReplyCount  { set; get; }
        public Int32    PraiseCount { set; get; }

    }
}
