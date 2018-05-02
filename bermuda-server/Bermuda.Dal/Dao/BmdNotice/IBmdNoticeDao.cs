namespace Bermuda.Dal.Dao
{
    using Model;

    public interface IBmdNoticeDao : IBaseDao<BmdNotice>
    {
        // add native methods here

        string Show();
    }
}
