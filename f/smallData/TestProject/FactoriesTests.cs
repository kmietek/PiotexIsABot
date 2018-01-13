using System.Windows.Forms;
using Factories.Facebook.Classes.FactoryClasses;
using Factories.Facebook.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class FactoriesTests
    {
        [TestMethod]
        public void EnumGetPageTest()
        {
            var browser = Factories.Facebook.Factory.FacebookFactory.GetWebBrowserPage(EFacebookEnum.Friends);

            Assert.AreEqual(typeof(WebBrowser),browser.GetType());
        }

        [TestMethod]
        public void GetFacebookClassTest()
        {
            var obj = Factories.Facebook.Factory.FacebookFactory.GetFacebookClasses(EFacebookEnum.Friends);

            Assert.AreEqual(typeof(WebBrowser), typeof(Friends));
        }
    }
}