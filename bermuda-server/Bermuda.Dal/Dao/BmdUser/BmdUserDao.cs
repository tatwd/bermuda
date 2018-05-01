namespace Bermuda.Dal.Dao
{
    using System;
    using Model;

    public class BmdUserDao
        : BaseDao<BmdUser>, IBmdUserDao
    {
        public string Show()
        {
            return ("Hello BmdUser DAO!");
        }
    }
}
