using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class JoinTopic
    {
        public int JoinTopicId { set; get; }
        public int TopicId     { set; get; }
        public int CurrentId   { set; get; }
    }
}
