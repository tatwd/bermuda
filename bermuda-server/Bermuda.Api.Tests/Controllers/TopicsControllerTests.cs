using Bermuda.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace Bermuda.Api.Controllers.Tests
{
    [TestClass()]
    public class TopicsControllerTests
    {
        TopicsController topicsCtrl = new TopicsController();

        [TestMethod()]
        public void GetAllTopicsTest()
        {
            // get all topics
            var actual = topicsCtrl.Get() as JsonResult<List<TopicViewModel>>;

            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Content[0].id);
        }
    }
}