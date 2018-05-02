using System.Web.Http;

namespace Bermuda.Api.Controllers
{
    using Bll.Service;
    using Model;
    using System.Web.Caching;

    public class TestController : ApiController
    {
        static Cache testCache = new Cache();

        public string BmdUserMsgGet()
        {
            return BmdUserService.ShowMsg();
        }

        public string BmdNoticeMsgGet()
        {
            return BmdNoticeService.ShowMsg();
        }

        [HttpGet]
        [Route("api/users/{id}")]
        public BmdUser GetBmdUserById(long id)
        {
            if (testCache[id.ToString()] == null)
            {
                var user = BmdUserService.GetUserById(id);
                if (user != null)
                    testCache.Insert(id.ToString(), user);
                return user;
            }

            return (BmdUser)testCache.Get(id.ToString());
        } 
    }
}
