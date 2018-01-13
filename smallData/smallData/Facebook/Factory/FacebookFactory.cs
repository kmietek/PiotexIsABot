using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using smallData.Facebook.Classes.AbstractClasses;
using smallData.Factories.PageFactory.Interfaces;
using EnumHelper = smallData.Helpers.EnumHelper;

namespace smallData.Factories.PageFactory
{
    public static class FacebookFactory
    {
        static FacebookFactory()
        {
            foreach (var page in EnumHelper.GetValues<EFacebookEnum>())          // insert into dictionary all keys from enum
            {
                PageDictionary.Add(page,new WebBrowser());
            }
        }


        private static Dictionary<EFacebookEnum,WebBrowser> PageDictionary = new Dictionary<EFacebookEnum, WebBrowser>();

        public static WebBrowser GetPage(EFacebookEnum enuma)
        {
            return PageDictionary[enuma];
        }


//        public static Dictionary<EFacebookEnum,bool> PageMethodsDictionary = new Dictionary<EFacebookEnum, bool>();

        public static FacebookPage GetObject(EFacebookEnum enuma)
        {
            var a = smallData.Helpers.AbstractHelpers.GetClassesFromAbstractClass<FacebookPage>();
            
            return a[enuma.ToString()] as FacebookPage;
        }

        public static bool StartPageMethod(EFacebookEnum enuma)
        {
            var a = smallData.Helpers.AbstractHelpers.GetClassesFromAbstractClass<FacebookPage>();
            var x = a[enuma.ToString()] as FacebookPage;
            bool tel = x.AmReady();
//            bool tel = x.GetData(PageDictionary[enuma]);
            return x != null && tel;
        }

        
    }
}