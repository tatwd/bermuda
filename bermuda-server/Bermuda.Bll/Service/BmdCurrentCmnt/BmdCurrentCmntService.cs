namespace Bermuda.Bll.Service
{
    using Dal.Dao;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BmdCurrentCmntService
        : BaseService<BmdCurrentCmnt, IBmdCurrentCmntDao>, IBmdCurrentCmntService
    {
        public IList<BmdCurrentCmnt> GetByCurrentId(Int64 currrentId)
        {
            return this
                .Select(x => x.CurrentId == currrentId)
                .OrderByDescending(x => x.CreatedAt)
                .ToList();
        }
    }
}
