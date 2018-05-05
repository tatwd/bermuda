using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Http;
using Bermuda.Api.Controllers;
using System.Collections;
using System.Web.Http.Results;

namespace Bermuda.Api.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        HomeController home = new HomeController();

        [TestMethod()]
        public void GetTest()
        {
            IHttpActionResult res = home.Get();
            JsonResult<object> json = res as JsonResult<object>;
            Hashtable mapHome = json.Content as Hashtable;

            Assert.IsNotNull(mapHome);
            Assert.IsNotNull(mapHome["home_hot_topics"]);
        }
    }
}