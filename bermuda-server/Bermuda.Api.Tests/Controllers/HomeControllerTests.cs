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
            Assert.IsNotNull(res);
            //Assert.IsNotNull(res as JsonResult<Hashtable>);
        }
    }
}