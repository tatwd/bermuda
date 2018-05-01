using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bermuda.Api.Controllers.Tests
{
    [TestClass()]
    public class TestControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            var testCtrl = new TestController();
            var res = testCtrl.Get();

            Assert.AreEqual("Hello BmdUser DAO!", res);
        }
    }
}