using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class NoticeTrace
    {
        public long     Id        { set; get; }
        public long     NoticeId  { set; get; }
        public long     UserId    { set; get; }
        public DateTime TraceDate { set; get; }
    }
}
