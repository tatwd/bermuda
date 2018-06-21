using Bermuda.Api.DataCache;
using Bermuda.Api.Models;
using Bermuda.Api.OAuth;
using Bermuda.Bll.Service;
using Bermuda.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Bermuda.Api.Controllers
{
    public class UserController : ApiController
    {
        IBmdUserService iservice = ServiceFactory.Get<IBmdUserService>();

        [Route("api/users/{id}")]
        public IHttpActionResult Get(Int64 id)
        {
            var vm = CacheEngine.GetData<UserViewModel>($"user_#{id}", () =>
            {
                var _user = iservice
                    .Select(x => x.Id == id)
                    .SingleOrDefault();
                return BaseUtil.ParseTo<UserViewModel>(_user);
            });

            return Json(vm);
        }

        [Route("api/users/top/{count}")]
        public IHttpActionResult Get(Int32 count)
        {
            var vm = CacheEngine.GetData<IList<UserViewModel>>("users_top", () =>
            {
                //var currentUser = AuthUtil.GetIdentityUser();
                var users = iservice.GetTop(count);
                var _vm = BaseUtil.ParseToList<UserViewModel>(users);

                //if (currentUser != null)
                //{
                //    var userFollowService = ServiceFactory.Get<IBmdUserFollowService>();
                //    var followingIds = userFollowService.GetFollowing(currentUser.id)
                //        .Select(x => x.FollowingId);

                //    foreach (var user in _vm)
                //    {
                //        if (followingIds.Contains(user.id))
                //            user.is_following = true;
                //    }
                //}

                AuthUtil.CheckFollowingUsers<UserViewModel>(_vm);

                return _vm;
            });

            return Json(vm);
        }
    }
}
