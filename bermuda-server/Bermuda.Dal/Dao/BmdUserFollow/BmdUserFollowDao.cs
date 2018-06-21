namespace Bermuda.Dal.Dao
{
    using System;
    using Model;
    using System.Linq;

    public class BmdUserFollowDao
        : BaseDao<BmdUserFollow>, IBmdUserFollowDao
    {
        public bool Unfollow(Int64 userId)
        {
            return false;
        }
    }
}
