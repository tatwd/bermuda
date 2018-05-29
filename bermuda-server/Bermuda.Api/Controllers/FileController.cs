using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Bermuda.Api.Controllers
{
    [RoutePrefix("api/files")]
    public class FileController : ApiController
    {
        [HttpPost]
        [Route("img/upload")]
        public IHttpActionResult UploadImg([FromBody]HttpPostedFile img)
        {
            //HttpContext.Current.Server.MapPath("")
            var fileName = img?.FileName ?? null;
            return Json(fileName);
        }
    }
}
