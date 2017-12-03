using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Goods
    {
        public long   Id       { set; get; }
        public long   UserId   { set; get; }
        public string Name     { set; get; }
        public string Type     { set; get; }
        public string Category { set; get; }
        public int    Qty      { set; get; }
        public string Img      { set; get; }
        public string Detail   { set; get; }
        public string Status   { set; get; }
        public string Remark   { set; get; }
    }
}
