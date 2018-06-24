namespace Bermuda.Bll.Service
{
    using Bermuda.Model;
    using System;
    using System.Collections.Generic;

    public interface IBmdCurrentCmntService : IBaseService<BmdCurrentCmnt>
    {
        // add native methods here
        IList<BmdCurrentCmnt> GetByCurrentId(Int64 currrentId);
    }
}
