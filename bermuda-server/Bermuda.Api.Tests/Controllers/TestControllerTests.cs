using Bermuda.Api.Controllers;
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

        [TestMethod()]
        public void UpdateUserTest()
        {
            var user = testCtrl.GetBmdUserById(10001);

            Assert.IsNotNull(user);

            user.Name = "test";
            user.Pwd = "test123";

            var isSuccessed = testCtrl.UpdateUser(user);

            Assert.IsTrue(isSuccessed);

            user = testCtrl.GetBmdUserById(10001);
        }

        [TestMethod()]
        public void GetNoticeListTest()
        {
            var notices = testCtrl.GetNoticeList(1);

            Assert.IsNotNull(notices);
            Assert.AreEqual(2, notices.Count);
        }
    }
}