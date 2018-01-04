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
            var data = "123href:11-2-1999/sdfsdf/".GetBirthDateofUser();
        }
        [TestMethod]
        public void GetUserSexTest()
        {
            var data = "document".GetSexOfUse();
        }
        [TestMethod]
        public void GetUserFriendsListTest()
        {
            var data = "123href:piotr/123href:adam/123hr:zle/123h:zle/".GetUriToFriends();
        }
        [TestMethod]
        public void GetUserResidenceTest()
        {
            var data = "document".GetUserResidence();
        }
    }
}
