using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CmntGoods
    {
        public int      CmntGoodsId { set; get; }
        public int      GoodsId     { set; get; }
        public int      CmntAuthor  { set; get; }
        public string   CmntContent { set; get; }
        public DateTime CmntDate    { set; get; }
        public int      PraiseCount { set; get; }
        public int      ReplyCount  { set; get; }
}
