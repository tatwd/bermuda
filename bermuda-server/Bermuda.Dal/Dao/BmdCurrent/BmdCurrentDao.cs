namespace Bermuda.Dal.Dao
{
    using Model;
    using System.Linq;

    public class BmdCurrentDao
        : BaseDao<BmdCurrent>, IBmdCurrentDao
    {
        public IQueryable<BmdCurrent> GetAll () => 
            this.Select(x => x.Id > 0 && x.UserId > 0);
    }
}
