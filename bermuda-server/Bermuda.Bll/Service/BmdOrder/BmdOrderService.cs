namespace Bermuda.Bll.Service
{
    using Bermuda.Dal.Dao;
    using Bermuda.Model;

    public class BmdOrderService
        : BaseService<BmdOrder, IBmdOrderDao>, IBmdOrderService
    {
    }
}
