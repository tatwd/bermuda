namespace Bermuda.Bll.Service
{
    using Model;

    public interface IBmdUserService : IBaseService<BmdUser>
    {
        string ShowMsg();
        BmdUser GetUserById(long id);
    }
}
