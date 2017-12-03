using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Root
    {
        public long   Id          { set; get; }
        public string Name        { set; get; }
        public int    Permission  { set; get; }
        public string PhoneNumber { set; get; }
        public string Email       { set; get; }
        public string Avatar      { set; get; }
        public string Remark      { set; get; }
    }
}
