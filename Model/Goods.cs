using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Goods
    {
        public int GoodsId { set; get; }
        public int OwnerId { set; get; }
        public char GoodsName { set; get; }
        public int Qty { set; get; }
        public char Img { set; get; }
    }
}
