using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Notice
    {
        public long     Id           { set; get; }
        public long     UserId       { set; get; }
        public string   Type         { set; get; }
        public string   Title        { set; get; }
        public string   GoodsSpecies { set; get; }
        public string   Place        { set; get; }
        public string   Location     { set; get; }
        public DateTime LfDate       { set; get; }
        public string   Img          { set; get; }
        public string   ContactWay   { set; get; }
        public string   Detail       { set; get; }
        public DateTime PublishDate  { set; get; }
        public string   Status       { set; get; } 
    }
}
