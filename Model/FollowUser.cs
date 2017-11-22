using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FollowUser
    {
        public int FollowUserId { set; get; }
        public int FollowingId  { set; get; }
        public int FollowerId   { set; get; }
    }
}
