using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bermuda.Model
{
    public class Follow
    {
        public Int64 Id          { set; get; }
        public Int64 UserId      { set; get; }
        public Int64 FollowingId { set; get; }

    }
}
