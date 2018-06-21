namespace Bermuda.Dal.Dao
{
    using Model;
    using System;

    public interface IBmdUserFollowDao : IBaseDao<BmdUserFollow>
    {
        // add native methods here

        bool Unfollow(Int64 userId);
    }
}
