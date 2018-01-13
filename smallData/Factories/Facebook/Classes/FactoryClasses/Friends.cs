using System.Windows.Forms;
using smallData.Factories.PageFactory.Abstract;

namespace smallData.Factories.PageFactory.Pages
{
    public class Friends : PageInfo
    {
        private static string oldVersion = "";

        public override bool GetData(WebBrowser page)
        {
            return true;

            page.Document.Body.ScrollIntoView(false);

            string document = page.DocumentText;

            if (document.Length > oldVersion.Length)
            {
                oldVersion = document;
                // method
                return false;
            }
            //to db
            return true;
        }

        public override object getObj()
        {
            return this;
        }
    }


}