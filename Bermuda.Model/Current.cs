using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bermuda.Model
{
    public class Current
    {
        public Int64    Id          { set; get; }
        public Int64    UserId      { set; get; }
        public String   Title       { set; get; }
        public String   Contents    { set; get; }
        public DateTime PublishDate { set; get; }
        public Int64    CmntCount   { set; get; }
        public Int64    StarCount   { set; get; }
        public Int64    PraiseCount { set; get; }
         
    }
}
