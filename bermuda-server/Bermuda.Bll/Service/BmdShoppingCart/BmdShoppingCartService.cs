namespace Bermuda.Bll.Service
{
    using Bermuda.Dal.Dao;
    using Bermuda.Model;

    public class BmdShoppingCartService
        : BaseService<BmdShoppingCart, IBmdShoppingCartDao>, IBmdShoppingCartService
    {
    }
}
