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
            IBmdUserService iuser = ServiceFactory.Get<IBmdUserService>();
            IList<NoticeViewModel> vm = new List<NoticeViewModel>();

            vm = CacheEngine.GetData<IList<NoticeViewModel>>("notices_all", () =>
                {
                    var notices = iservice
                        .Select(x => x.IsSolved == 0) // 未解决
                        .OrderByDescending(x => x.CreatedAt)
                        .ToList();

                    var _vms = BaseUtil.ParseToList<NoticeViewModel>(notices);

                    foreach (var _vm in _vms)
                    {
                        var _user = iuser.GetUserById(_vm.user_id);
                        _vm.user_name = _user.Name;
                    }

                    return _vms;
                });

            return Json(vm);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
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
