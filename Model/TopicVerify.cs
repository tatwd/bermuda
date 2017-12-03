using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TopicVerify
    {
        public long     Id         { get; set; }
        public long     TopicId    { get; set; }
        public long     RootId     { get; set; }
        public DateTime VerifyDate { get; set; }
        public byte     IsPassed   { get; set; }
    }
}
