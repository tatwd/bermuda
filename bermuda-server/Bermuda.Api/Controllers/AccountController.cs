using Bermuda.Api.Models;
using Bermuda.Bll.Service;
using Bermuda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bermuda.Api.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        IBmdUserService iservice = ServiceFactory.Get<IBmdUserService>();

        [HttpPost]
        [Route("register")]
        public IHttpActionResult Post([FromBody]RegisterViewModel user)
        {
            bool success = false;
            string msg = "注册失败！";

            if (ModelState.IsValid)
            {
                //var _user = new BmdUser
                //{
                //    Name = user.username,
                //    Pwd = user.password,
                //    Email = user.email
                //};
                //success = iservice.SignUp(_user);
                success = true;
                msg = "注册成功！";
            }

            return Json(new { success, msg });
        }
    }
}
