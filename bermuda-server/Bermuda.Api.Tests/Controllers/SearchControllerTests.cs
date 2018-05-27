using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bermuda.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bermuda.Api.Models;
using System.Web.Http.Results;

namespace Bermuda.Api.Controllers.Tests
{
    [TestClass()]
    public class SearchControllerTests
    {
        SearchController ctrler = new SearchController();

        [TestMethod()]
        public void SearchNoticesTest()
        {
            var actual = ctrler.Notices("test") as JsonResult<NoticeSearchModel>;
            Assert.IsNotNull(actual, "should not be null");
        }
    }
}