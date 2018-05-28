using Bermuda.Api.DataCache;
using Bermuda.Api.Models;
using Bermuda.Bll.Service;
using Bermuda.Common;
using Bermuda.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Results;

namespace Bermuda.Api.Controllers
{
    [RoutePrefix("api/search")]
    public class SearchController : ApiController
    {
        [HttpGet]
        [Route("notices/{q}")]
        public IHttpActionResult Notices(string q)
        {
            var vm = CacheEngine.GetData<IList<NoticeSearchModel>>($"search_notices_all", () =>
            {
                var notices = ServiceFactory.Get<IBmdNoticeService>()
                    .Select(x => x.IsSolved == 0)
                    .ToList();
                return BaseUtil.ParseToList<NoticeSearchModel>(notices);
            });

            if (vm == null)
                return Json(vm);

            var path = HostingEnvironment.MapPath(
                $"{ConfigurationManager.AppSettings["IndexDir"].ToString()}/notices");
            SearchUtil.LoadFSDirectory(path);
            SearchUtil.CreateIndex<NoticeSearchModel>(vm);

            var result = SearchUtil.SearchFullText<NoticeSearchModel>(q, 5);

            if (result.Count <= 0)
                result = null;

            return Json(result);
        }

        [HttpGet]
        [Route("topics/{q}/{page:int?}")]
        public IHttpActionResult Topics(string q, int page = 1)
        {
            return Json($"q={q} page={page}");
        }
    }
}
