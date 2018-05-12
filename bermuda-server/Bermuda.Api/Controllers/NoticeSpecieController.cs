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
            IList<BmdNoticeSpecie> species = new List<BmdNoticeSpecie>();
            IList<NoticeSpecieViewModel> vm = new List<NoticeSpecieViewModel>();

            species = CacheEngine.GetData<IList<BmdNoticeSpecie>>("species_all",
                () => iservice
                    .Select(x => x.Id > 0)
                    .ToList());

            vm = BaseUtil.ParseToList<NoticeSpecieViewModel>(species);

            return Json(vm);
        }

        [HttpGet]
        [Route("api/notice/specie/{id}")]
        public IHttpActionResult Get(Int64 id)
        {
            BmdNoticeSpecie species = new BmdNoticeSpecie();
            NoticeSpecieViewModel vm = new NoticeSpecieViewModel();

            species = CacheEngine.GetData<BmdNoticeSpecie>($"specie_#{id}",
                () => iservice
                    .Select(x => x.Id == id)
                    .SingleOrDefault());

            vm = BaseUtil.ParseTo<NoticeSpecieViewModel>(species);

            return Json(vm);
        }

        [HttpGet]
        [Route("api/notice/species/top")]
        public IHttpActionResult Get(string type = "top")
        {
            IList<BmdNoticeSpecie> species = new List<BmdNoticeSpecie>();
            IList<NoticeSpecieViewModel> vm = new List<NoticeSpecieViewModel>();

            species = CacheEngine.GetData<IList<BmdNoticeSpecie>>("species_top",
                () => iservice
                    .Select(x => x.Id > 0)
                    .OrderByDescending(x => x.NoticeCount) // desc
                    .ToList());

            vm = BaseUtil.ParseToList<NoticeSpecieViewModel>(species);

            return Json(vm);
        }
    }
}
