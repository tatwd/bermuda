using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class VerifyTopic
    {
        public int VerifyTopicId { get; set; }
        public int TopicId { get; set; }
        public int RootId { get; set; }
        public int IsPassed { get; set; }
    }
}
