namespace Bermuda.Dal.Dao
{
    using Model;
    using System.Linq;

    public interface IBmdCurrentDao : IBaseDao<BmdCurrent>
    {
        // add native methods here
        IQueryable<BmdCurrent> GetAll();
    }
}
