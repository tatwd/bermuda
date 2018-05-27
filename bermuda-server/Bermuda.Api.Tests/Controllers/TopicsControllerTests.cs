using Bermuda.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace Bermuda.Api.Controllers.Tests
{
    [TestClass()]
    public class TopicsControllerTests
    {
        TopicController ctrler = new TopicController();

        [TestMethod()]
        public void GetAllTopicsTest()
        {
            // get all topics
            var actual = ctrler.Get() as JsonResult<IList<TopicViewModel>>;

            Assert.IsNotNull(actual, "Topics should not be null");
            Assert.IsNotNull(actual.Content, "JSON Content should not be null");
        }
    }
}