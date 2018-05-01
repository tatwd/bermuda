namespace Bermuda.Dal.Dao
{
    using Model;

    public class BmdNoticeDao
        : BaseDao<BmdNotice>, IBmdNoticeDao
    {
        public string Show()
        {
            return ("Hello BmdNotice DAO!");
        }
    }
}
