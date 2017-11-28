using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TopicVerify
    {
        public int      Id         { get; set; }
        public int      TopicId    { get; set; }
        public int      RootId     { get; set; }
        public DateTime VerifyDate { get; set; }
        public int      IsPassed   { get; set; }
    }
}
