namespace Bermuda.Bll.Service
{
    public class ServiceFactory
    {
        public static IBaseService<T> GetService<T>()
            where T : class, new()
        {
            return null;
        }
    }
}
