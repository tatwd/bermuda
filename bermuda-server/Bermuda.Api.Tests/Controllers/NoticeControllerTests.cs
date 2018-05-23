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

            Assert.IsNotNull(actual, "should not be null");
        }
    }
}