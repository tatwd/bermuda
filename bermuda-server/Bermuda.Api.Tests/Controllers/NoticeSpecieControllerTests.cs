using Bermuda.Api.Controllers;
using Bermuda.Api.Models;
using Bermuda.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace Bermuda.Api.Controllers.Tests
{
    [TestClass()]
    public class NoticeSpecieControllerTests
    {
        NoticeSpecieController ctrler = new NoticeSpecieController();

        [TestMethod()]
        public void GetAllNoticeSpeciesTest()
        {
            var actual = ctrler.Get() as JsonResult<IList<NoticeSpecieViewModel>>;

            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Content[0]);
        }

        [TestMethod()]
        public void GetTopTopicsTest()
        {
            var actual = ctrler.Get("top") as JsonResult<IList<NoticeSpecieViewModel>>;

            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Content[0]);
        }

        [TestMethod()]
        public void GetNoticeSpecieByIdTest()
        {
            var actual = ctrler.Get(1) as JsonResult<NoticeSpecieViewModel>;

            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Content.id);
        }
    }
}