namespace Bermuda.Bll.Service
{
    using Model;

    public interface IBmdUserService : IBaseService<BmdUser>
    {
        // add native methods here

        string ShowMsg();
        BmdUser GetUserById(long id);
    }
}
