using Bermuda.Api.DataCache;
using Bermuda.Api.Models;
using Bermuda.Bll.Service;
using Bermuda.Common;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Results;

namespace Bermuda.Api.Controllers
{
    //[RoutePrefix("api/search")]
    public class SearchController : ApiController
    {
        [HttpGet]
        //[Route("api/search/notices/{q}")]
        public IHttpActionResult Notices(string q)
        {
            var vm = CacheEngine.GetData<IList<NoticeSearchModel>>($"notices_all", () =>
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
            return Json(result);
        }
    }
}
