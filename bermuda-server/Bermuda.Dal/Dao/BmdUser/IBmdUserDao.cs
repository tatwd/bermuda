namespace Bermuda.Dal.Dao
{
    using Model;

    public interface IBmdUserDao : IBaseDao<BmdUser>
    {
        // add native methods here

        string Show();
    }
}
