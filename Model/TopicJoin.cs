using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TopicJoin
    {
        public long Id        { get; set; }
        public long TopicId   { get; set; }
        public long CurrentId { get; set; }
    }
}
