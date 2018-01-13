using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FacebookToolsBP.FacebookInfoFactory
{
    public class FacebookInfoFactory
    {
        private static WebBrowser _page;

        public static Dictionary<FacebookInfoEnum, Func<bool>> facebookProcessesDictionary = new Dictionary<FacebookInfoEnum, Func<bool>>
        {
            {FacebookInfoEnum.likes, () => new FacebookInfoLikes().GetDataList(_page)},
            {FacebookInfoEnum.friends, () => new FacebookInfoFriends().GetDataList(_page)}
        };

        public static Dictionary<FacebookInfoEnum, WebBrowser> facebookPagesDictionary = new Dictionary<FacebookInfoEnum, WebBrowser>
        {
            {FacebookInfoEnum.friends, new WebBrowser()},
            {FacebookInfoEnum.likes, new WebBrowser()}
        };

        public static bool GetInfoFromFacebookPage(WebBrowser page, FacebookInfoEnum enumInfo)
        {
            _page = page;
            return facebookProcessesDictionary[enumInfo]();
        }
    }
}