using System;
using System.Collections.Generic;
using System.Reflection;
using Factories.DataBase;
using Factories.Facebook.Classes.BasicClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smallData.Facebook.Classes.AbstractClasses;
using smallData.Facebook.Classes.BasicClasses;
using smallData.Factories.PageFactory;
using smallData.Factories.PageFactory.Pages;
using smallData.Helpers;

namespace TestProject
{
    [TestClass]
    public class DataBaseTests
    {
        [TestMethod]
        public void DbStartTest()
        {
            var b = new Dictionary<EFacebookEnum, List<BasicClass>>
            {
                {
                    EFacebookEnum.friends, new List<BasicClass>
                    {
                        new FriendBasic()
                    }
                },
                {
                    EFacebookEnum.likes, new List<BasicClass>
                    {
                        new LikeBasic()
                    }
                },
                {
                    EFacebookEnum.about, new List<BasicClass>
                    {
                        new AboutBasic()
                    }
                }
            };
            DBManager.StartDBProcesses(b);
        }
    }

    public class MyFieldClassA
    {
        public string Field = "A Field";
    }


    public class MyFieldInfoClass
    {
        public static void Main()
        {
            MyFieldClassA myFieldObjectA = new MyFieldClassA();

            Type myTypeA = typeof(MyFieldClassA);
            FieldInfo myFieldInfo = myTypeA.GetField("Field");
            myFieldInfo.GetValue(myFieldObjectA);
        }
    }
}