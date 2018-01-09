using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bermuda.Model
{
    public class Notice
    {
        public Int64    Id           { set; get; }
        public Int64    UserId       { set; get; }
        public Int64    SpeciesId    { set; get; }
        public String   Type         { set; get; }
        public String   Title        { set; get; }
        public String   Place        { set; get; }
        public String   Location     { set; get; }
        public String   LfDate       { set; get; }
        public String   Img          { set; get; }
        public String   ContactWay   { set; get; }
        public String   Detail       { set; get; }
        public DateTime PublishDate  { set; get; }
        public Int64    CmntCount    { set; get; }
        public Int64    TraceCount   { set; get; }
        public String   Status       { set; get; } 
    }
}
