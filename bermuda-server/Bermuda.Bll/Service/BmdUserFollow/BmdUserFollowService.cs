namespace Bermuda.Bll.Service
{
    using System;
    using System.Collections.Generic;
    using Bermuda.Dal.Dao;
    using Bermuda.Model;
    using System.Linq;

    public class BmdUserFollowService
        : BaseService<BmdUserFollow, IBmdUserFollowDao>, IBmdUserFollowService
    {
        public IList<BmdUserFollow> GetFollowers(Int64 userId)
        {
            return idao.Select(x => x.FollowingId == userId)
                .OrderByDescending(x => x.CreatedAt)
                .ToList();
        }

        public IList<BmdUserFollow> GetFollowing(Int64 userId)
        {
            return idao.Select(x => x.UserId == userId)
                .OrderByDescending(x => x.CreatedAt)
                .ToList();
        }
    }
}
