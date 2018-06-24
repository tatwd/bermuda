using Bermuda.Api.DataCache;
using Bermuda.Api.Models;
using Bermuda.Api.OAuth;
using Bermuda.Bll.Service;
using Bermuda.Common;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Bermuda.Api.Controllers
{
    [RoutePrefix("api/search")]
    public class SearchController : ApiController
    {
        private readonly static string INDEX_DIR = ConfigurationManager.AppSettings["IndexDir"].ToString();

        [HttpGet]
        [Route("notices/{q}")]
        public IHttpActionResult Notices(string q)
        {
            var vm = CacheEngine.GetData<IList<NoticeSearchModel>>($"search_notices_all", () =>
            {
                var notices = ServiceFactory.Get<IBmdNoticeService>()
                    .Select(x => x.IsSolved == 0)
                    .OrderByDescending(x => x.TraceCount) // 根据追踪数排序
                    .ToList();
                return BaseUtil.ParseToList<NoticeSearchModel>(notices);
            });

            if (vm == null)
                return Json(vm);

            var path = HttpContext.Current.Server.MapPath($"{INDEX_DIR}/notices");
            SearchUtil.LoadFSDirectory(path);
            SearchUtil.CreateIndex<NoticeSearchModel>(vm);

            var result = SearchUtil.SearchFullText<NoticeSearchModel>(q, 5);
            return Json(result);
        }

        [HttpGet]
        [Route("users/{q}")]
        public IHttpActionResult Users(string q)
        {
            var vm = CacheEngine.GetData<IList<UserSearchModel>>($"search_users_all", () =>
            {
                var users = ServiceFactory.Get<IBmdUserService>()
                    .Select(x => x.Id > 0)
                    .OrderByDescending(x => x.HelpCount) // 根据帮助数排序
                    .ToList();
                return BaseUtil.ParseToList<UserSearchModel>(users);
            });

            if (vm == null)
                return Json(vm);

            // 开始搜索
            var path = HttpContext.Current.Server.MapPath($"{INDEX_DIR}/users");
            SearchUtil.LoadFSDirectory(path);
            SearchUtil.CreateIndex<UserSearchModel>(vm);

            var result = SearchUtil.SearchFullText<UserSearchModel>(q, 10);
            AuthUtil.CheckFollowingUsers<UserSearchModel>(result);
            return Json(result);
        }

        [HttpGet]
        [Route("topics/{q}")]
        public IHttpActionResult Topics(string q)
        {
            var vm = CacheEngine.GetData<IList<TopicSearchModel>>($"search_topics_all", () =>
            {
                var topics = ServiceFactory.Get<IBmdTopicService>()
                    .Select(x => x.IsPassed == 1)
                    .OrderByDescending(x => x.JoinCount) // 根据参与人数排序
                    .ToList();
                return BaseUtil.ParseToList<TopicSearchModel>(topics);
            });

            if (vm == null)
                return Json(vm);

            // 开始搜索
            var path = HttpContext.Current.Server.MapPath($"{INDEX_DIR}/topics");
            SearchUtil.LoadFSDirectory(path);
            SearchUtil.CreateIndex<TopicSearchModel>(vm);

            var result = SearchUtil.SearchFullText<TopicSearchModel>(q, 10);
            return Json(result);
        }

        [HttpGet]
        [Route("currents/{q}")]
        public IHttpActionResult Currents(string q)
        {
            var vm = CacheEngine.GetData<IList<CurrentSearchModel>>($"search_currents_all", () =>
            {
                var currents = ServiceFactory.Get<IBmdCurrentService>()
                    .GetAll()
                    .OrderByDescending(x => x.CreatedAt)
                    .ToList();
                return BaseUtil.ParseToList<CurrentSearchModel>(currents);
            });

            if (vm == null)
                return Json(vm);

            var path = HttpContext.Current.Server.MapPath($"{INDEX_DIR}/currents");
            SearchUtil.LoadFSDirectory(path);
            SearchUtil.CreateIndex<CurrentSearchModel>(vm);

            var result = SearchUtil.SearchFullText<CurrentSearchModel>(q, 5);
            return Json(result);
        }
    }
}
