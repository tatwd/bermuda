using Bermuda.Api.DataCache;
using Bermuda.Api.Models;
using Bermuda.Bll.Service;
using Bermuda.Common;
using Bermuda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bermuda.Api.Controllers
{
    [RoutePrefix("api/notices")]
    public class NoticeController : ApiController
    {
        IBmdNoticeService iservice = ServiceFactory.Get<IBmdNoticeService>();

        [Route()]
        public IHttpActionResult Get()
        {
            var vm = CacheEngine.GetData<IList<NoticeViewModel>>("notices_all", () =>
            {
                var _vm = new List<NoticeViewModel>();
                var userService = ServiceFactory.Get<IBmdUserService>();
                var notices = iservice
                    .Select(x => x.IsSolved == 0)
                    .OrderByDescending(x => x.CreatedAt)
                    .ToList();

                foreach (var notice in notices)
                {
                    var user = userService.GetUserById(notice.UserId.Value);
                    var vmnotice = BaseUtil.DeepParseTo<NoticeViewModel, UserViewModel>(notice, user);
                    _vm.Add(vmnotice);
                }

                return _vm.Count <= 0 ? null : _vm;
            });

            return Json(vm);
        }

        [Route("{id}")]
        public IHttpActionResult Get(Int64 id)
        {
            var vm = CacheEngine.GetData<NoticeViewModel>($"notice_#{id}", () =>
            {
                var notice = iservice
                    .Select(x => x.Id == id)
                    .SingleOrDefault();
                var user = notice!= null
                    ? ServiceFactory
                        .Get<IBmdUserService>()
                        .GetUserById(notice.UserId.Value)
                    : null;

                return BaseUtil.DeepParseTo<NoticeViewModel, UserViewModel>(notice, user);
            });

            return Json(vm);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
