namespace Bermuda.Bll.Service
{
    using System;

    // 使用单利模式按需获取实例
    public sealed class ServiceFactory
    {
        public static T Get<T>() where T : class
        {
            return Nested<T>.instance;
        }

        class Nested<T> where T : class
        {
            static Nested() { }

            internal static readonly T instance = GetNestedServiceInstance();

            static T GetNestedServiceInstance()
            {
                string className = String.Format("Bermuda.Bll.Service.{0}", typeof(T).Name.Substring(1));
                Type type = Type.GetType(className);
                return (T)Activator.CreateInstance(type);
            }
        }
    }
}
