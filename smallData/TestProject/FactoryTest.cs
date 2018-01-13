using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smallData.Factories.PageFactory;

namespace TestProject
{
    [TestClass]
    public class FactoryTest
    {
        [TestMethod]
        public void GetValuesFromPageDictionaryTest()
        {
            var webB1 = FacebookFactory.GetPage(EFacebookEnum.friends);
            var webB2 = new WebBrowser();
            Assert.AreEqual(webB2.GetType(),webB1.GetType());
        }

        [TestMethod]
        public void GetObjTest()
        {
            var obj = FacebookFactory.GetObject(EFacebookEnum.friends);
        }
    }
}