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
    [RoutePrefix("")]
    public class NoticeController : ApiController
    {
        IBmdNoticeService iservice = ServiceFactory.Get<IBmdNoticeService>();

        [Route("api/notices")]
        public IHttpActionResult Get()
        {
            var vm = GetAllCurrentsFromCache();
            return Json(vm);
        }

        [Route("api/notices/{id}")]
        public IHttpActionResult Get(Int64 id)
        {
            var vm = GetNoticeByIdFromCache(id);
            return Json(vm);
        }

        [Authorize]
        [Route("api/notice")]
        public IHttpActionResult Post(NewNoticeViewModel vm)
        {
            bool success = false;

            if (ModelState.IsValid)
            {
                success = iservice.Insert(new BmdNotice
                {
                    UserId = vm.user_id,
                    SpecieId = vm.specie_id,
                    Title = vm.title,
                    Type = vm.type,
                    ImgUrl = vm.img_url,
                    EventTimeDesc = vm.event_time_desc,
                    Place = vm.place,
                    FullPlace = vm.full_place,
                    ContactWay = vm.contact_way,
                    Detail = vm.detail
                });
            }

            return Json(new { success });
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
