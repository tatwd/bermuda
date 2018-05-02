using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bermuda.Api.Controllers.Tests
{
    using Model;

    [TestClass()]
    public class TestControllerTests
    {
        TestController testCtrl = new TestController();

        [TestMethod()]
        public void GetTest()
        {
            var getUserMsg = testCtrl.BmdUserMsgGet();
            var getUserMsg1 = testCtrl.BmdUserMsgGet();
            var getNoticeMsg = testCtrl.BmdNoticeMsgGet();

            Assert.AreEqual("Hello BmdUser DAO!", getUserMsg);
            Assert.AreEqual("Hello BmdNotice DAO!", getNoticeMsg);
        }

        [TestMethod()]
        public void GetUserByIdTest()
        {
            var user1 = testCtrl.GetBmdUserById(10001);
            var user2 = testCtrl.GetBmdUserById(10001);

            Assert.IsNotNull(user1);
            Assert.IsNotNull(user2);
        }
    }
}