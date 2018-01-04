using System;
using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class HelpersTestClass
    {
        [TestMethod]
        public void GetUserBirthDayTest()
        {
            var data = "document".GetBirthDateofUser();
        }
        [TestMethod]
        public void GetUserSexTest()
        {
            var data = "document".GetSexOfUse();
        }
        [TestMethod]
        public void GetUserFriendsListTest()
        {
            var data = "document".GetUriToFriends();
        }
        [TestMethod]
        public void GetUserResidenceTest()
        {
            var data = "document".GetUserResidence();
        }
    }
}
