using System.Web.Http;

namespace Bermuda.Api.Controllers
{
    using Bll.Service;

    public class TestController : ApiController
    {
        public string BmdUserMsgGet()
        {
            return BmdUserService.ShowMsg();
        }

        public string BmdNoticeMsgGet()
        {
            return BmdNoticeService.ShowMsg();
        }
    }
}
