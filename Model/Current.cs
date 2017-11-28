using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Current
    {
        public int      Id          { set; get; }
        public int      UserId      { set; get; }
        public int      TopicId     { set; get; }
        public string   Title       { set; get; }
        public string   Contents    { set; get; }
        public DateTime PublishDate { set; get; }
        public int      CmntCount   { set; get; }
        public int      StarCount   { set; get; }
        public int      PraiseCount { set; get; }
         
    }
}
