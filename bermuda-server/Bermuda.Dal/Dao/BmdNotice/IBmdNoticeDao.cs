namespace Bermuda.Dal.Dao
{
    using Model;

    public interface IBmdNoticeDao : IBaseDao<BmdNotice>
    {
        string Show();
    }
}
