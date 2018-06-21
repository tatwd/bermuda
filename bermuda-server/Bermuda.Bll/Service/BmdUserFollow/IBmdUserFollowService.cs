namespace Bermuda.Bll.Service
{
    using Bermuda.Model;
    using System;
    using System.Collections.Generic;

    public interface IBmdUserFollowService : IBaseService<BmdUserFollow>
    {
        // add native methods here

        IList<BmdUserFollow> GetFollowers(Int64 userId);
        IList<BmdUserFollow> GetFollowing(Int64 userId);
    }
}
