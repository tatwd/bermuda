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

            var getUserMsg = testCtrl.BmdUserMsgGet();
            var getNoticeMsg = testCtrl.BmdNoticeMsgGet();

            Assert.AreEqual("Hello BmdUser DAO!", getUserMsg);
            Assert.AreEqual("Hello BmdNotice DAO!", getNoticeMsg);
        }
    }
}