using Bermuda.Api.DataCache;
using Bermuda.Api.Models;
using Bermuda.Bll.Service;
using Bermuda.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bermuda.Api.Controllers
{
    [RoutePrefix("api/currents")]
    public class CurrentController : ApiController
    {
        IBmdCurrentService iservice = ServiceFactory.Get<IBmdCurrentService>();

        [Route()]
        public IHttpActionResult Get()
        {
            var vm = GetAllCurrentsFromCache();
            return Json(vm);
        }

        [Route("{id}")]
        public IHttpActionResult Get(Int64 id)
        {
            var vm = GetCurrentByIdFromCache(id);
            return Json(vm);
        }

        [Route("user/{uid}")]
        public IHttpActionResult GetByUserId(Int64 uid)
        {
            var vm = GetCurrentByUserIdFromCache(uid);
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

        /**
         *  utils for current stuff
         */

        private IList<CurrentViewModel> GetAllCurrentsFromCache()
        {
            return CacheEngine.GetData<IList<CurrentViewModel>>("currents_all", () =>
            {
                var _vm = new List<CurrentViewModel>();
                var userService = ServiceFactory.Get<IBmdUserService>();
                var currents = iservice
                    .GetAll()
                    .OrderByDescending(x => x.CreatedAt)
                    .ToList();

                foreach (var current in currents)
                {
                    var user = userService.GetUserById(current.UserId.Value);
                    var vmnotice = BaseUtil.DeepParseTo<CurrentViewModel, UserViewModel>(current, user);
                    _vm.Add(vmnotice);
                }

                return _vm.Count <= 0 ? null : _vm;
            });
        }

        private CurrentViewModel GetCurrentByIdFromCache(Int64 id)
        {
            return CacheEngine.GetData<CurrentViewModel>($"current_#{id}", () =>
            {
                var current = iservice
                    .Select(x => x.Id == id)
                    .SingleOrDefault();
                var user = current != null
                    ? ServiceFactory
                        .Get<IBmdUserService>()
                        .GetUserById(current.UserId.Value)
                    : null;

                return BaseUtil.DeepParseTo<CurrentViewModel, UserViewModel>(current, user);
            });
        }

        private CurrentViewModel GetCurrentByUserIdFromCache(Int64 uid)
        {
            return CacheEngine.GetData<CurrentViewModel>($"current_by_#{uid}", () =>
            {
                var current = iservice
                    .Select(x => x.UserId == uid)
                    .SingleOrDefault();
                var user = current != null
                    ? ServiceFactory
                        .Get<IBmdUserService>()
                        .GetUserById(current.UserId.Value)
                    : null;

                return BaseUtil.DeepParseTo<CurrentViewModel, UserViewModel>(current, user);
            });
        }
    }
}
