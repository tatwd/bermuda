namespace Bermuda.Bll.Service
{
    using Bermuda.Dal.Dao;
    using Bermuda.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BmdCurrentCmntReplyService
        : BaseService<BmdCurrentCmntReply, IBmdCurrentCmntReplyDao>, IBmdCurrentCmntReplyService
    {
        public IList<BmdCurrentCmntReply> GetByCmntId(Int64 cmntId)
        {
            return this
                .Select(x => x.CmntId == cmntId)
                .OrderBy(x => x.CreatedAt)
                .ToList();
        }
    }
}
