using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bermuda.Model
{
    public class CurrentCmnt
    {
        public Int64    Id          { set; get; }
        public Int64    CurrentId   { set; get; }
        public Int64    UserId      { set; get; }
        public String   Contents    { set; get; }
        public DateTime CmntDate    { set; get; }
        public Int64    PraiseCount { set; get; }
        public Int64    ReplyCount  { set; get; }
    }
}
