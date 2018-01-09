using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bermuda.Model
{
    public class User
    {
        public Int64  Id             { set; get; }
        public String Name           { set; get; }
        public String PhoneNumber    { set; get; }
        public String Email          { set; get; }
        public String Type           { set; get; }
        public String Pwd            { set; get; }
        public String Avatar         { set; get; }
        public Int32  Rate           { set; get; }
        public Int64  FollowingCount { set; get; }
        public Int64  FollowerCount  { set; get; }
    }
}
