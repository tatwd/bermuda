namespace Bermuda.Bll.Service
{
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBmdUserService : IBaseService<BmdUser>
    {
        // add native methods here

        BmdUser GetUserById(long id);

        /// <summary>
        /// Sign in with username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        BmdUser SignInWithUsernameAndPassword(string username, string password);

        // async task
        Task<BmdUser> SignInWithUsernameAndPasswordAsync(string username, string password);

        /// <summary>
        /// Sign up a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool SignUp(BmdUser user);

        IList<BmdUser> GetTop(Int32 count);
    }
}
