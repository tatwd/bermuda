using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bermuda.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bermuda.Model;
using System.Web.Http.Results;

namespace Bermuda.Api.Controllers.Tests
{
    [TestClass()]
    public class TopicsControllerTests
    {
        TopicsController topicsCtrl = new TopicsController();

        [TestMethod()]
        public void GetTest()
        {
            // get all topics
            var result = topicsCtrl.Get() as JsonResult<IList<BmdTopic>>;
            //Assert.Fail("failed to get all topics", result); 
            //Assert.Inconclusive("should get all topics", result);
        }
    }
}