using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bermuda.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Bermuda.Api.Models;

namespace Bermuda.Api.Controllers.Tests
{
    [TestClass()]
    public class NoticeControllerTests
    {
        NoticeController ctrler = new NoticeController();

        [TestMethod()]
        public void GetAllNotSolvedNoticesTest()
        {
            var actual = ctrler.Get() as JsonResult<IList<NoticeViewModel>>;
            Assert.IsNotNull(actual, "Notices should not be null");
            Assert.IsNotNull(actual.Content[0].user, "User should not be null");
        }

        [TestMethod()]
        public void GetNoticeById()
        {
            var actual = ctrler.Get(1) as JsonResult<NoticeViewModel>;
            Assert.IsNotNull(actual.Content, "Notice Should not be null");
            Assert.IsNotNull(actual.Content.user, "User Should not be null");
        }
    }
}