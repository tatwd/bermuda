using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bermuda.Model
{
    public class TopicJoin
    {
        public Int64 Id        { get; set; }
        public Int64 TopicId   { get; set; }
        public Int64 CurrentId { get; set; }
    }
}
