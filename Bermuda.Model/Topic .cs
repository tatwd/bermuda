using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bermuda.Model
{
    public class Topic
    {
        public Int64    Id         { get; set; }
        public String   Name       { get; set; }
        public Int64    UserId     { get; set; }
        public String   Detail     { get; set; }
        public Int64    JoinCount  { get; set; }
        public DateTime CreateDate { get; set; }
        public String   Img        { set; get; }
        public Byte     IsPassed   { set; get; }
    }
}
