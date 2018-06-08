namespace Bermuda.Bll.Service
{
    using Dal.Dao;
    using Model;
    using System.Linq;

    public class BmdCurrentService
        : BaseService<BmdCurrent, IBmdCurrentDao>, IBmdCurrentService
    {
        public IQueryable<BmdCurrent> GetAll() => idao.GetAll();
    }
}
