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
            var vm = GetAllCurrentsFromCache();
            return Json(vm);
        }

        [Route("{id}")]
        public IHttpActionResult Get(Int64 id)
        {
            var vm = GetNoticeByIdFromCache(id);
            return Json(vm);
        }

        // 从缓存中获取所有启事
        private IList<NoticeViewModel> GetAllCurrentsFromCache()
        {
            return CacheEngine.GetData<IList<NoticeViewModel>>("notices_all", () =>
            {
                var notices = iservice.GetNotSolvedNotices()
                    .OrderByDescending(x => x.CreatedAt)
                    .ToList();
                var _vm = ParseToCurrentViewModeList(notices);
                return _vm.Count <= 0 ? null : _vm;
            });
        }

        // 根据 Id 从缓存中获取所有启事
        private NoticeViewModel GetNoticeByIdFromCache(Int64 id)
        {
            return CacheEngine.GetData<NoticeViewModel>($"notice_#{id}", () =>
            {
                var notice = iservice
                    .Select(x => x.Id == id)
                    .SingleOrDefault();
                return ParseToNoticeViewMode(notice);
            });
        }

        private IList<NoticeViewModel> ParseToCurrentViewModeList(IEnumerable<BmdNotice> notices)
        {
            var vmlist = new List<NoticeViewModel>();
            var userService = ServiceFactory.Get<IBmdUserService>();

            foreach (var notice in notices)
            {
                var user = notice?.UserId.HasValue ?? false
                    ? userService.GetUserById(notice.UserId.Value)
                    : null;
                vmlist.Add(
                    BaseUtil.DeepParseTo<NoticeViewModel, UserViewModel>(notice, user));
            }

            return vmlist;
        }

        private NoticeViewModel ParseToNoticeViewMode(BmdNotice notice)
        {
            var userService = ServiceFactory.Get<IBmdUserService>();
            var user = notice?.UserId.HasValue ?? false
                ? userService.GetUserById(notice.UserId.Value)
                : null;
            return BaseUtil.DeepParseTo<NoticeViewModel, UserViewModel>(notice, user);
        }
    }
}
