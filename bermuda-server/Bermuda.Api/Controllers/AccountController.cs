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
                var newUser = new BmdUser
                {
                    Name = user.username,
                    Pwd = user.password,
                    Email = user.email
                };

                if (iservice.Select(x => x.Name == newUser.Name || x.Email == newUser.Email)
                    .FirstOrDefault() != null)
                {
                    msg = "用户名或邮箱已被注册";
                }
                else
                {
                    success = iservice.SignUp(newUser);
                }

                if (success)
                    msg = "注册成功！";
            }

            return Json(new { success, msg });
        }
    }
}
