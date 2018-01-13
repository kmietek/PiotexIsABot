using System.Collections.Generic;
using System.Windows.Forms;
using Factories.Facebook.Classes.Abstract;

namespace Factories.Facebook.Factory
{
    public static class FacebookFactory
    {
        static FacebookFactory()
        {
            foreach (var page in Helpers.EnumHelpers.GetValues<Enums.EFacebookEnum>())          // insert into dictionary all keys from enum
            {
                PageDictionary.Add(page, new WebBrowser());
            }
        }
        private static Dictionary<Enums.EFacebookEnum, WebBrowser> PageDictionary = new Dictionary<Enums.EFacebookEnum, WebBrowser>();

        public static WebBrowser GetWebBrowserPage(Enums.EFacebookEnum enuma)
        {
            return PageDictionary[enuma];
        }

        public static FacebookPage GetFacebookClasses(Enums.EFacebookEnum enuma)
        {
            var a = Helpers.AbstractHelpers.GetClassesFromAbstractClass<FacebookPage>();
//            var a = Helpers.AbstractHelpers.GetClassesFromAbstractClass<FacebookPage<object>>();

            return a[enuma.ToString()] as FacebookPage;
        }

    }
}