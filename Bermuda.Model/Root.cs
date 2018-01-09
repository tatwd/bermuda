using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bermuda.Model
{
    public class Root
    {
        public Int64  Id          { set; get; }
        public String Name        { set; get; }
        public Int32  Permission  { set; get; }
        public String PhoneNumber { set; get; }
        public String Email       { set; get; }
        public String Avatar      { set; get; }
        public String Remark      { set; get; }
    }
}
