namespace Bermuda.Bll.Service
{
    using Dal.Dao;
    using Model;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class BmdNoticeSpecieService
        : BaseService<BmdNoticeSpecie, IBmdNoticeSpecieDao>, IBmdNoticeSpecieService
    {
    }
}
