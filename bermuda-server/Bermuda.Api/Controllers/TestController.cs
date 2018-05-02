using System.Web.Http;

namespace Bermuda.Api.Controllers
{
    using Bll.Service;
    using Model;
    using System.Web.Caching;

    public class TestController : ApiController
    {
        IBmdUserService iuser = ServiceFactory<IBmdUserService>.ServiceInstance;
        IBmdNoticeService inotice = ServiceFactory<IBmdNoticeService>.ServiceInstance;

        static Cache testCache = new Cache();

        public string BmdUserMsgGet()
        {
            return iuser.ShowMsg();
        }

        public string BmdNoticeMsgGet()
        {
            return inotice.ShowMsg();
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
    }
}
