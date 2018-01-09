using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bermuda.Model
{
    public class Species
    {
        public Int64  Id          { set; get; }
        public String Name        { set; get; }
        public String Img         { set; get; }
        public Int64  NoticeCount { set; get; }
    }
}
