namespace Bermuda.Bll.Service
{
    using Dal.Dao;
    using Model;
    using System.Linq;
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class BmdUserService 
        : BaseService<BmdUser, IBmdUserDao>, IBmdUserService
    {
        public BmdUser GetUserById(long id)
        {
            return idao
                .Select(x => x.Id == id)
                .SingleOrDefault();
        }

        public BmdUser SignInWithUsernameAndPassword(string username, string password)
        {
            return idao
                .Select(x => x.Name == username && x.Pwd == password)
                .SingleOrDefault();
        }

        public Task<BmdUser> SignInWithUsernameAndPasswordAsync(string username, string password)
        {
            return Task.Run(() =>
            {
                return this.SignInWithUsernameAndPassword(username, password);
            });
        }

        public bool SignUp(BmdUser user)
        {
            idao.Insert(user);
            return idao.SaveChanges();
        }

        public IList<BmdUser> GetTop(int count)
        {
            return idao
                .Select(x => x.Id > 0)
                .OrderByDescending(x => x.HelpCount.Value)
                .Take(count)
                .ToList();
        }
    }
}
