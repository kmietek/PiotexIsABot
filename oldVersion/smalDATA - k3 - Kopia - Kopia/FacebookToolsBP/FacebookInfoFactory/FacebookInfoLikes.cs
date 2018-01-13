using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using ToDelLibrary;

namespace FacebookToolsBP.FacebookInfoFactory
{
    public class FacebookInfoLikes : FacebookInfo
    {
        private static bool addedI = false;
        private static List<string> old_list = new List<string>();
        private string userid = ToDel.UserID;

        public override bool GetDataList(WebBrowser page)
        {
            var newList = SelectAllLikes(page);
            ToDel.likesStop = false;

            if (old_list.Count != newList.Count)
            {
                old_list = newList;
                return false;
            }

            //int id = PostgreComands.GetLastID("usersidtable");
            if (!addedI)
            {
                for (int i = 0; i < old_list.Count; i++)
                {
                    PostgreComands.Insert("userlikes", "facebookid,facebooklikename", userid + "," + old_list[i]);
                }
                addedI = true;
            }
            ToDel.likesStop = true;
            Feedback.feedback.Likes.Checked = true;
            return true;
        }

        private List<string> SelectAllLikes(WebBrowser page)
        {
            string document = "";
            List<string> fbName = new List<string>();

            page.Document.Body.ScrollIntoView(false);

            document = page.DocumentText;

            for (int i = 0; i < document.Length; i++)
            {
                //<div class="fsl fwb fcb"><a href="https://www.facebook.com/
                if (i > 30 &&
                    document[i - 29] == 'c' &&
                    document[i - 28] == 'l' &&
                    document[i - 27] == 'a' &&
                    document[i - 26] == 's' &&
                    document[i - 25] == 's' &&
                    document[i - 24] == '=' &&
                    document[i - 23] == '"' &&
                    document[i - 22] == 'f' &&
                    document[i - 21] == 's' &&
                    document[i - 20] == 'l' &&
                    document[i - 19] == ' ' &&
                    document[i - 18] == 'f' &&
                    document[i - 17] == 'w' &&
                    document[i - 16] == 'b' &&
                    document[i - 15] == ' ' &&
                    document[i - 14] == 'f' &&
                    document[i - 13] == 'c' &&
                    document[i - 12] == 'b' &&
                    document[i - 11] == '"' &&
                    document[i - 10] == '>' &&
                    document[i - 9] == '<' &&
                    document[i - 8] == 'A' &&
                    document[i - 7] == ' ' &&
                    document[i - 6] == 'h' &&
                    document[i - 5] == 'r' &&
                    document[i - 4] == 'e' &&
                    document[i - 3] == 'f' &&
                    document[i - 2] == '=' &&
                    document[i - 1] == '"' )
                {
                    int iCopy = i + "https://www.facebook.com/".Length ;
                    string dataToAdd = "";
                    while (document[iCopy] != '/' && document[iCopy] != '&')
                    {
                        dataToAdd += document[iCopy];
                        iCopy++;
                        if (dataToAdd == "pages")
                        {
                            while (document[iCopy] != '"')
                            {
                                dataToAdd += document[iCopy];
                                iCopy++;
                            }
                            break;
                        }
                    }
                    fbName.Add(dataToAdd);
                }
            }
            return fbName;
        }
    }
}