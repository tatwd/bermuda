using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GoodsCmnt
    {
        public int      Id          { set; get; }
        public int      GoodsId     { set; get; }
        public int      UserId      { set; get; }
        public string   Contents    { set; get; }
        public DateTime CmntDate    { set; get; }
        public int      PraiseCount { set; get; }
        public int      ReplyCount  { set; get; }
    }
}
