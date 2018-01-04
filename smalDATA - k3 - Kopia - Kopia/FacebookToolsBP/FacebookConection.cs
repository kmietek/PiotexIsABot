using System;
using System.Windows.Forms;

namespace FacebookToolsBP
{
    public class FacebookConection
    {
        public void Connect(WebBrowser page, string id, string argumentWhereToGo)
        {
            string file = "https://www.facebook.com";
            string argumentSelector = "&sk=";

            if (id[0] == 'p' &&
                id[1] == 'r' &&
                id[2] == 'o' &&
                id[3] == 'f' &&
                id[4] == 'i' &&
                id[5] == 'l' &&
                id[6] == 'e' &&
                id[7] == '.' &&
                id[8] == 'p' &&
                id[9] == 'h' &&
                id[10] == 'p' &&
                id[11] == '?')
            {
                page.Navigate(String.Format("{0}/{1}{2}{3}",file , id , argumentSelector, argumentWhereToGo));
            }
            else
            {
                page.Navigate(String.Format("{0}/{1}/{2}", file, id, argumentWhereToGo));
            }
            //? GC.Collect(0);GC.Collect(0,GCCollectionMode.Forced);
        }
    }
}