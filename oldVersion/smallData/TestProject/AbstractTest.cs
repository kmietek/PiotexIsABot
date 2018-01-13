using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms.VisualStyles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smallData.Factories.PageFactory;
using smallData.Factories.PageFactory.Abstract;
using smallData.Factories.PageFactory.Interfaces;
using smallData.Factories.PageFactory.Pages;

namespace TestProject
{
    [TestClass]
    public class AbstractTest
    {
        [TestMethod]
        public void GetItemFromAbstractClassTest()
        {
            var a = smallData.Helpers.AbstractHelpers.GetClassesFromAbstractClass<PageInfo>();
            object q = a[PageEnum.friends.ToString()];

            Assert.AreEqual(q.GetType(),typeof(Friends));
        }

    }
}