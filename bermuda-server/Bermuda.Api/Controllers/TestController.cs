using System.Web.Http;

namespace Bermuda.Api.Controllers
{
    using Bll.Service;
    using Model;
    using System.Web.Caching;

    public class TestController : ApiController
    {
        IBmdUserService iuser = ServiceFactory.Get<IBmdUserService>();
        IBmdNoticeService inotice = ServiceFactory.Get<IBmdNoticeService>();

        Cache testCache = new Cache();

        public string BmdUserMsgGet()
        {
            IBmdUserService iuserx = ServiceFactory.Get<IBmdUserService>();

            return iuserx.ShowMsg();
        }

        public string BmdNoticeMsgGet()
        {
            IBmdNoticeService inoticex = ServiceFactory.Get<IBmdNoticeService>();
            return inoticex.ShowMsg();
        }

        [HttpGet]
        [Route("api/users/{id}")]
        public BmdUser GetBmdUserById(long id)
        {
            if (testCache[id.ToString()] == null)
            {
                var user = iuser.GetUserById(id);
                if (user != null)
                    testCache.Insert(id.ToString(), user);
                return user;
            }

            return (BmdUser)testCache.Get(id.ToString());
        }

        public bool UpdateUser(BmdUser newUser)
        {
            bool isSuccessed = iuser.Update(newUser);

            if (isSuccessed)
            {
                testCache[newUser.Id.ToString()] = newUser;
            }

            return isSuccessed;
        }
    }
}
