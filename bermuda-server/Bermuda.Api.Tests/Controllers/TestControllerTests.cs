using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bermuda.Api.Controllers.Tests
{
    [TestClass()]
    public class TestControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            TestController testCtrl = new TestController();

            var getUser = testCtrl.BmdUserMsgGet();
            var getNotice = testCtrl.BmdNoticeMsgGet();

            Assert.AreEqual("Hello BmdUser DAO!", getUser);
            Assert.AreEqual("Hello BmdNotice DAO!", getNotice);
        }
    }
}