namespace Bermuda.Dal.Dao
{
    using Model;

    public interface IBmdUserDao : IBaseDao<BmdUser>
    {
        string Show();
    }
}
