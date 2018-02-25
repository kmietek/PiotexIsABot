using System.IO;
using System.Windows.Forms;
using Factories.Facebook.Classes.BasicClasses;
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

        [TestMethod]
        public void LivingTest()
        {
            var obj = new MainLiving();

            StreamReader red = new StreamReader("C:\\Users\\Piotr\\Desktop\\peter\\smallData\\TestProject\\Pages\\Living.html");

            var list = obj.GetData(red.ReadToEnd());
        }

        [TestMethod]
        public void ContactInfoTest()
        {
            var obj = new MainContactInfo();

            StreamReader red = new StreamReader("C:\\Users\\Piotr\\Desktop\\peter\\smallData\\TestProject\\Pages\\ContactInfo.html");

            var list = obj.GetData(red.ReadToEnd());
        }

    }
}