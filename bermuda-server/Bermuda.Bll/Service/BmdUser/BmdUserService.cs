namespace Bermuda.Bll.Service
{
    using Dal.Dao;
    using Model;
    using System.Linq;

    public class BmdUserService 
        : BaseService<BmdUser, IBmdUserDao>, IBmdUserService
    {
        public string ShowMsg()
        {
            return idao.Show();
        }

        public BmdUser GetUserById(long id)
        {
            return idao.Select(x => x.Id == id).FirstOrDefault();
        }
    }
}
