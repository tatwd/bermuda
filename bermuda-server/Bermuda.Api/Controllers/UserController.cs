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
    public class UserController : ApiController
    {
        IBmdUserService iservice = ServiceFactory.Get<IBmdUserService>();

        [Route("api/users/top/{count}")]
        public IHttpActionResult Get(Int32 count)
        {
            IList<UserViewModel> vm = new List<UserViewModel>();

            vm = CacheEngine.GetData<IList<UserViewModel>>("users_top", () =>
            {
                var _users = iservice.GetTop(count);
                var _vms = BaseUtil.ParseToList<UserViewModel>(_users);
                return _vms;
            });

            return Json(vm);
        }

        [Route("api/user/{id}")]
        public IHttpActionResult Get(Int64 id)
        {
            UserViewModel vm = new UserViewModel();

            vm = CacheEngine.GetData<UserViewModel>($"user_#{id}", () =>
            {
                var _user = iservice
                    .Select(x => x.Id == id)
                    .SingleOrDefault();
                var _vm = BaseUtil.ParseTo<UserViewModel>(_user);
                return _vm;
            });

            return Json(vm);
        }
    }
}
