using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using FacebookToolsBP.FacebookInfoFactory;
using ManagerBP;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProjectBP
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ProcessesManager manager = new ProcessesManager();
            manager.StartAllProcesses();
        }

        [TestMethod]
        public void FriendsTest()
        {
            WebBrowser FacebookFriendsPage = new WebBrowser();
            FacebookInfoFriends fif = new FacebookInfoFriends();
            FacebookFriendsPage.Navigate(@"https://www.facebook.com/piotr.kubon.99/friends");
            for (int i = 0; i < 100; i++)
            {
                System.Threading.Thread.Sleep(10);
                System.Windows.Forms.Application.DoEvents();
            }

            bool list = fif.GetDataList(FacebookFriendsPage);
        }

        [TestMethod]
        public void LikesTest()
        {
            WebBrowser FacebookPage = new WebBrowser();
            FacebookInfoLikes fif = new FacebookInfoLikes();
            FacebookPage.Navigate(@"https://www.facebook.com/piotr.kubon.99/likes");
            for (int i = 0; i < 100; i++)
            {
                System.Threading.Thread.Sleep(10);
                System.Windows.Forms.Application.DoEvents();
            }

            var a = fif.GetDataList(FacebookPage);


            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(3000);
                bool list = fif.GetDataList(FacebookPage);
            }
        }
    }
}
