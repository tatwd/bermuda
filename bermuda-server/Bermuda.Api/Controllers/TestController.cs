namespace Bermuda.Api.Controllers
{
    using Bll.Service;
    using Model;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Caching;
    using System.Web.Http;

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


        [HttpGet]
        [Route("api/notices/{pageIndex}")]
        public IList<BmdNotice> GetNoticeList(int pageIndex)
        {
            const string KEY = "HomeNotices";
            const int SIZE = 5;

            if (testCache[KEY] == null)
            {
                Hashtable map = new Hashtable();

                var notices = inotice.GetNoticeByPage(SIZE, pageIndex, x => x.Id, x => x.Status == 0).ToList();
                map.Add(pageIndex, notices);

                if(notices != null)
                    testCache.Insert(KEY, map);

                return notices;
            } 
            else
            {
                var map = testCache[KEY] as Hashtable;
                bool isContainsKey = map.ContainsKey(pageIndex);

                if (!isContainsKey)
                {
                    var notices = inotice.GetNoticeByPage(SIZE, pageIndex, x => x.Id, x => x.Status == 0).ToList();
                    map.Add(pageIndex, notices);
                    return notices;
                }
                return map[pageIndex] as IList<BmdNotice>;
            }
        }
    }
}
