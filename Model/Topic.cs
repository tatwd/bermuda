using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Topic
    {
        public int      TopicId   { get; set; }
        public string   TopicName { get; set; }
        public int      CreatorId { get; set; }
        public string   TopicDesc { get; set; }
        public int      JoinCount { get; set; }
        public DateTime CreatDate { get; set; }
    }
}
