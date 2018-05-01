namespace Bermuda.Bll.Service
{
    using Dal.Dao;
    using Model;

    public class BmdNoticeService
        : BaseService<BmdNotice, IBmdNoticeDao>, IBmdNoticeService
    {
        public static string ShowMsg()
        {
            return idao.Show();
        }
    }
}
