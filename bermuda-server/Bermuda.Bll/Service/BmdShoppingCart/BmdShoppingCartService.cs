namespace Bermuda.Bll.Service
{
    using Dal.Dao;
    using Model;

    public class BmdShoppingCartService
        : BaseService<BmdShoppingCart, IBmdShoppingCartDao>, IBmdShoppingCartService
    {
    }
}
