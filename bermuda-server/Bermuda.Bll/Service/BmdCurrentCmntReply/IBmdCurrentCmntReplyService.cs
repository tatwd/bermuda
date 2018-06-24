namespace Bermuda.Bll.Service
{
    using Bermuda.Model;
    using System;
    using System.Collections.Generic;

    public interface IBmdCurrentCmntReplyService : IBaseService<BmdCurrentCmntReply>
    {
        // add native methods here
        IList<BmdCurrentCmntReply> GetByCmntId(Int64 cmntId);
    }
}
