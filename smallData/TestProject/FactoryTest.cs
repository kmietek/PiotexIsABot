using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smallData.Factories.PageFactory;
using smallData.Factories.PageFactory.Pages;

namespace TestProject
{
    [TestClass]
    public class FactoryTest
    {
        [TestMethod]
        public void GetValuesFromPageDictionaryTest()
        {
            var webB1 = PageFactory.GetPage(EnumPages.Friends);
            var webB2 = new WebBrowser();
            Assert.AreEqual(webB2.GetType(),webB1.GetType());
        }

        [TestMethod]
        public void GetObjTest()
        {
            var obj = MainFactory.GetMainClass(EnumPages.Friends);
        }

    }
}