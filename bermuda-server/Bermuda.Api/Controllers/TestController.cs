using System.Web.Http;

namespace Bermuda.Api.Controllers
{
    using Bll.Service;

    public class TestController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            return BmdUserService.ShowMsg();
        }
    }
}
