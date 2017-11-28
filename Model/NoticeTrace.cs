using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class NoticeTrace
    {
        public int      Id        { set; get; }
        public int      NoticeId  { set; get; }
        public int      UserId    { set; get; }
        public DateTime TraceDate { set; get; }
    }
}
