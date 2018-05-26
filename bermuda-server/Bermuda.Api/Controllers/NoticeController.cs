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
    public class NoticeController : ApiController
    {
        IBmdNoticeService iservice = ServiceFactory.Get<IBmdNoticeService>();

        [Route("api/notices")]
        public IHttpActionResult Get()
        {
            IList<NoticeViewModel> vm = new List<NoticeViewModel>();
            vm = CacheEngine.GetData<IList<NoticeViewModel>>("notices_all", () =>
                {
                    var userService = ServiceFactory.Get<IBmdUserService>();
                    var notices = iservice
                        .Select(x => x.IsSolved == 0) // 未解决
                        .OrderByDescending(x => x.CreatedAt)
                        .ToList();

                    var _vms = BaseUtil.ParseToList<NoticeViewModel>(notices);

                    foreach (var _vm in _vms)
                    {
                        var _user = userService.GetUserById(_vm.user_id);
                        _vm.user_name = _user.Name;
                    }

                    return _vms;
                });
            return Json(vm);
        }

        [Route("api/notice/{id}")]
        public IHttpActionResult Get(Int64 id)
        {
            NoticeViewModel vm = new NoticeViewModel();
            vm = CacheEngine.GetData<NoticeViewModel>($"notice_#{id}", () =>
                {
                    var userService = ServiceFactory.Get<IBmdUserService>();
                    var _notice = iservice
                        .Select(x => x.Id == id)
                        .SingleOrDefault();
                    if (_notice != null)
                    {
                        var _user = userService.GetUserById(Convert.ToInt64(_notice.UserId));
                        var _vm = BaseUtil.ParseTo<NoticeViewModel>(_notice);
                        _vm.user = BaseUtil.ParseTo<UserViewModel>(_user);
                        return _vm;
                    }
                    else
                    {
                        return null;
                    }
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
