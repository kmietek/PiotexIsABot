using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms.VisualStyles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smallData.Facebook.Classes.AbstractClasses;
using smallData.Factories.PageFactory;
using smallData.Factories.PageFactory.Pages;
using smallData.Helpers;

namespace TestProject
{
    [TestClass]
    public class AbstractTest
    {
        [TestMethod]
        public void GetItemFromAbstractClassTest()
        {
            var a = AbstractHelpers.GetClassesFromAbstractClass<FacebookPage>();
            object q = a[EFacebookEnum.friends.ToString()];

            Assert.AreEqual(q.GetType(),typeof(Friends));
        }

    }
}