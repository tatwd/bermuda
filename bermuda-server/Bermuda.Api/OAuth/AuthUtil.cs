using Bermuda.Api.Models;
using Bermuda.Bll.Service;
using Bermuda.Common;
using Bermuda.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bermuda.Api.OAuth
{
    public class AuthUtil
    {
        public static UserViewModel GetIdentityUser()
        {
            var json = HttpContext.Current.User.Identity.Name;
            var user = JsonConvert.DeserializeObject<UserViewModel>(json);
            return user;
        }

        public static string GetUserJsonString(BmdUser user)
        {
            var vm = BaseUtil.ParseTo<UserViewModel>(user);
            var json = JsonConvert.SerializeObject(vm);
            return json;
        }

        public static void CheckFollowingUsers<T>(IList<T> users) where T : BaseUserViewModel
        {
            var currentUser = AuthUtil.GetIdentityUser();

            if (currentUser != null)
            {
                var userFollowService = ServiceFactory.Get<IBmdUserFollowService>();
                var followingIds = userFollowService.GetFollowing(currentUser.id)
                    .Select(x => x.FollowingId);

                foreach (var user in users)
                {
                    if (followingIds.Contains(user.id))
                        user.is_following = true;
                }
            }
        }
    }
}
