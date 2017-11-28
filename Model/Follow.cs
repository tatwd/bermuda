using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Follow
    {
        public int Id          { set; get; }
        public int UserId      { set; get; }
        public int FollowingId { set; get; }

    }
}
