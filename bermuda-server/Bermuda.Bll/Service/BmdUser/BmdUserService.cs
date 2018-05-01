namespace Bermuda.Bll.Service
{
    using Dal.Dao;
    using Model;

    public class BmdUserService 
        : BaseService, IBmdUserService
    {
        public static string ShowMsg()
        {
            IBmdUserDao idao = new BmdUserDao();
            return idao.Show();
        }
    }
}
