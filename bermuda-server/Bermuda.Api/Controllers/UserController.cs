using Bermuda.Api.DataCache;
using Bermuda.Api.Models;
using Bermuda.Bll.Service;
using Bermuda.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Bermuda.Api.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        IBmdUserService iservice = ServiceFactory.Get<IBmdUserService>();

        [Route("{id}")]
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

        [Route("top/{count}")]
        public IHttpActionResult Get(Int32 count)
        {
            var vm = CacheEngine.GetData<IList<UserViewModel>>("users_top", () =>
            {
                var _users = iservice.GetTop(count);
                return BaseUtil.ParseToList<UserViewModel>(_users);
            });

            return Json(vm);
        }
    }
}
