using Bermuda.Api.DataCache;
using Bermuda.Api.Models;
using Bermuda.Api.OAuth;
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
    public class UserFollowController : ApiController
    {
        IBmdUserFollowService iservice = ServiceFactory.Get<IBmdUserFollowService>();

        [HttpGet]
        [Route("api/user/{uid}/followers")]
        public IHttpActionResult GetFollower(Int64 uid)
        {
            var vm = CacheEngine.GetData<IList<UserViewModel>>($"user_#{uid}_followers", () =>
            {
                var userService = ServiceFactory.Get<IBmdUserService>();
                var userIds = iservice.GetFollowers(uid)
                    .Select(x => x.UserId);
                var users = userService.Select(x => userIds.Contains(x.Id)).ToList();
                return BaseUtil.ParseToList<UserViewModel>(users);
            });

            return Json(vm);
        }

        [HttpGet]
        [Route("api/user/{uid}/following")]
        public IHttpActionResult GetFollowing(Int64 uid)
        {
            var vm = CacheEngine.GetData<IList<UserViewModel>>($"user_#{uid}_following", () =>
            {
                var userService = ServiceFactory.Get<IBmdUserService>();
                var userIds = iservice.GetFollowing(uid)
                    .Select(x => x.FollowingId);
                var users = userService.Select(x => userIds.Contains(x.Id)).ToList();
                return BaseUtil.ParseToList<UserViewModel>(users);
            });
            return Json(vm);
        }

        [Authorize]
        [HttpPost]
        [Route("api/user/following/{uid}")]
        //public IHttpActionResult Post([FromUri]UserFollowingViewModel vm)
        public IHttpActionResult Post([FromUri]Int64? uid)
        {
            var success = false;
            if (uid.HasValue && uid.Value > 0)
            {
                var currentUser = AuthUtil.GetIdentityUser();
                success = iservice.Insert(new BmdUserFollow
                {
                    UserId = currentUser.id,
                    FollowingId = uid.Value
                });
            }
            return Json(new { success });
        }

        [Authorize]
        [HttpDelete]
        [Route("api/user/following/{uid}")]
        public IHttpActionResult Delete(int uid)
        {
            var currentUser = AuthUtil.GetIdentityUser();
            var following = iservice.Select(x => x.UserId == currentUser.id && x.FollowingId == uid)
                .SingleOrDefault();
            var success = iservice.Delete(following);
            return Json(new { success });
        }
    }
}
