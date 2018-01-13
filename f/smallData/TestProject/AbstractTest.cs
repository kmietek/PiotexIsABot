using System;
using System.Runtime.InteropServices.ComTypes;
using Factories.Facebook.Classes.Abstract;
using Factories.Facebook.Classes.FactoryClasses;
using Factories.Facebook.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class AbstractTest
    {
        [TestMethod]
        public void GetItemFromAbstractClassTest()
        {
            var a = Helpers.AbstractHelpers.GetClassesFromAbstractClass<FacebookPage>();
            object q = a[EFacebookEnum.Friends.ToString()];

            Assert.AreEqual(q.GetType(), typeof(Friends));
        }
    }
}