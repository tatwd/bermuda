using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Follow
    {
        public long Id          { set; get; }
        public long UserId      { set; get; }
        public long FollowingId { set; get; }

    }
}
