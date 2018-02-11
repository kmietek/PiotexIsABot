using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smallData.Factories.PageFactory;

namespace TestProject
{
    [TestClass]
    public class EnumTest
    {
        [TestMethod]
        public void GetItemFromEnumTest()
        {
            var iEnumerator = smallData.Helpers.EnumHelper.GetValues<EnumPages>();
            var friends = iEnumerator.ElementAt(0);
            Assert.AreEqual(EnumPages.Friends, friends);
        }
    }
}