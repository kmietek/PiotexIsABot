using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using smallData.Factories.PageFactory.Abstract;
using smallData.Factories.PageFactory.Interfaces;
using smallData.Helpers;

namespace smallData.Factories.PageFactory
{
    public static class PageFactory
    {
        static PageFactory()
        {
            foreach (var page in EnumHelper.GetValues<PageEnum>())          // insert into dictionary all keys from enum
            {
                PageDictionary.Add(page,new WebBrowser());
            }
        }


        private static Dictionary<PageEnum,WebBrowser> PageDictionary = new Dictionary<PageEnum, WebBrowser>();

        public static WebBrowser GetPage(PageEnum enuma)
        {
            return PageDictionary[enuma];
        }


//        public static Dictionary<PageEnum,bool> PageMethodsDictionary = new Dictionary<PageEnum, bool>();

        public static PageInfo GetObject(PageEnum enuma)
        {
            var a = smallData.Helpers.AbstractHelpers.GetClassesFromAbstractClass<PageInfo>();
            
            return a[enuma.ToString()] as PageInfo;
        }

        public static bool StartPageMethod(PageEnum enuma)
        {
            var a = smallData.Helpers.AbstractHelpers.GetClassesFromAbstractClass<PageInfo>();
            var x = a[enuma.ToString()] as PageInfo;
            bool tel = x.GetData(PageDictionary[enuma]);
            object tesssl = x.getObj();
            return x != null && tel;
        }

        
    }
}