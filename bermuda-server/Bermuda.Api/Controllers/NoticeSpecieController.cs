using Bermuda.Api.DataCache;
using Bermuda.Api.Models;
using Bermuda.Bll.Service;
using Bermuda.Common;
using Bermuda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Bermuda.Api.Controllers
{
    public class NoticeSpecieController : ApiController
    {
        IBmdNoticeSpecieService iservice = ServiceFactory.Get<IBmdNoticeSpecieService>();

        [HttpGet]
        [Route("api/notice/species")]
        public IHttpActionResult Get()
        {
            var vm = CacheEngine.GetData<IList<NoticeSpecieViewModel>>("species_all", () =>
            {
                var species = iservice
                    .Select(x => x.Id > 0)
                    .ToList();
                return BaseUtil.ParseToList<NoticeSpecieViewModel>(species);
            });

            return Json(vm);
        }

        [HttpGet]
        [Route("api/notice/species/{id}")]
        public IHttpActionResult Get(Int64 id)
        {
            var vm = CacheEngine.GetData<NoticeSpecieViewModel>($"specie_#{id}", () =>
            {
                var specie = iservice
                    .Select(x => x.Id == id)
                    .SingleOrDefault();
                return BaseUtil.ParseTo<NoticeSpecieViewModel>(specie);
            });

            return Json(vm);
        }

        [HttpGet]
        [Route("api/notice/species/{type}/{count}")]
        public IHttpActionResult Get(string type, int count = 10)
        {
            var vm = CacheEngine.GetData<IList<NoticeSpecieViewModel>>($"species_{type}_{count}", () =>
            {
                IList<BmdNoticeSpecie> species = new List<BmdNoticeSpecie>();

                if (type.Equals("top", StringComparison.OrdinalIgnoreCase))
                {
                    species = iservice
                        .Select(x => x.Id > 0)
                        .OrderByDescending(x => x.NoticeCount) // desc
                        .Take(count)
                        .ToList();
                }
                else if (type.Equals("all", StringComparison.OrdinalIgnoreCase))
                {
                    species = iservice
                        .Select(x => x.Id > 0)
                        .Take(count)
                        .ToList();
                }

                return BaseUtil.ParseToList<NoticeSpecieViewModel>(species);
            });

            return Json(vm);
        }
    }
}
