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
    public class CurrentController : ApiController
    {
        IBmdCurrentService iservice = ServiceFactory.Get<IBmdCurrentService>();

        [Route("api/currents")]
        public IHttpActionResult Get()
        {
            var vm = GetAllCurrentsFromCache();
            return Json(vm);
        }

        [Route("api/currents/{id}")]
        public IHttpActionResult Get(Int64 id)
        {
            var vm = GetCurrentByIdFromCache(id);
            return Json(vm);
        }

        [Route("api/currents/top/{count}")]
        public IHttpActionResult Get(Int32 count)
        {
            var vm = GetTopCurrentsFromCache(count);
            return Json(vm);
        }

        [Route("api/user/{uid}/currents")]
        public IHttpActionResult GetByUserId(Int64 uid)
        {
            var vm = GetCurrentByUserIdFromCache(uid);
            return Json(vm);
        }

        [Route("api/topic/{tid}/currents")]
        public IHttpActionResult GetByTopicId(Int64 tid)
        {
            var vm = GetCurrentsByTopicIdFromCache(tid);
            return Json(vm);
        }

        // 从缓存中获取所有动态
        private IList<CurrentViewModel> GetAllCurrentsFromCache()
        {
            return CacheEngine.GetData<IList<CurrentViewModel>>("currents_all", () =>
            {
                var currents = iservice.GetAll()
                    .OrderByDescending(x => x.CreatedAt)
                    .ToList();
                var _vm = ParseToCurrentViewModeList(currents);
                return _vm.Count <= 0 ? null : _vm;
            });
        }

        // 从缓存中获取热门动态
        private IList<CurrentViewModel> GetTopCurrentsFromCache(Int32 count)
        {
            return CacheEngine.GetData<IList<CurrentViewModel>>($"currents_top_${count}", () =>
            {
                var currents = iservice.GetAll()
                    .OrderByDescending(x => x.PraiseCount)
                    .Take(count)
                    .ToList();
                var _vm = ParseToCurrentViewModeList(currents);
                return _vm.Count <= 0 ? null : _vm;
            });
        }

        // 根据 Id 从缓存中获取所有动态
        private CurrentViewModel GetCurrentByIdFromCache(Int64 id)
        {
            return CacheEngine.GetData<CurrentViewModel>($"current_#{id}", () =>
            {
                var current = iservice
                    .Select(x => x.Id == id)
                    .SingleOrDefault();
                return ParseToCurrentViewMode(current);
            });
        }

        // 根据 UserId 从缓存中获取所有动态
        private CurrentViewModel GetCurrentByUserIdFromCache(Int64 uid)
        {
            return CacheEngine.GetData<CurrentViewModel>($"current_by_#{uid}", () =>
            {
                var current = iservice
                    .Select(x => x.UserId == uid)
                    .SingleOrDefault();
                return ParseToCurrentViewMode(current);
            });
        }

        // 根据 TopicId 从缓存中获取所有动态
        // 构建的是 TopicJoinViewModel
        private TopicJoinViewModel GetCurrentsByTopicIdFromCache(Int64 tid)
        {
            return CacheEngine.GetData<TopicJoinViewModel>($"currents_join_#{tid}", () =>
            {
                var vm = new TopicJoinViewModel();
                var topicService = ServiceFactory.Get<IBmdTopicService>();
                var topicJoinService = ServiceFactory.Get<IBmdTopicJoinService>();

                vm.topic = ParseToTopicViewMode(
                    topicService.GetTopicById(tid));

                vm.currents = ParseToCurrentViewModeList(
                    topicJoinService.GetCurrentsByTopicId(tid));

                return vm;
            });
        }

        private IList<CurrentViewModel> ParseToCurrentViewModeList(IEnumerable<BmdCurrent> currents)
        {
            var vmlist = new List<CurrentViewModel>();
            var userService = ServiceFactory.Get<IBmdUserService>();

            foreach (var current in currents)
            {
                var user = current?.UserId.HasValue ?? false
                    ? userService.GetUserById(current.UserId.Value)
                    : null;
                vmlist.Add(
                    BaseUtil.DeepParseTo<CurrentViewModel, UserViewModel>(current, user));
            }

            return vmlist;
        }

        private CurrentViewModel ParseToCurrentViewMode(BmdCurrent current)
        {
            var userService = ServiceFactory.Get<IBmdUserService>();
            var user = current?.UserId.HasValue ?? false
                ? userService.GetUserById(current.UserId.Value)
                : null;
            return BaseUtil.DeepParseTo<CurrentViewModel, UserViewModel>(current, user);
        }

        private TopicViewModel ParseToTopicViewMode(BmdTopic topic)
        {
            var userService = ServiceFactory.Get<IBmdUserService>();
            var user = topic?.UserId.HasValue ?? false
                ? userService.GetUserById(topic.UserId.Value)
                : null;
            return BaseUtil.DeepParseTo<TopicViewModel, UserViewModel>(topic, user);
        }
    }
}
