namespace Bermuda.Bll.Service
{
    using Bermuda.Dal.Dao;
    using Bermuda.Model;

    public class BmdProductService
        : BaseService<BmdProduct, IBmdProductDao>, IBmdProductService
    {
    }
}
