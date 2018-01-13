using System.Collections.Generic;
using System.Windows.Forms;
using smallData.Facebook.Classes.AbstractClasses;
using smallData.Facebook.Classes.BasicClasses;

namespace smallData.Factories.PageFactory.Pages
{
    public class Friends : FacebookPage
    {
        private static string oldVersion = "";


        public override List<BasicClass> GetData(string page)
        {
            return new List<BasicClass>{new Like()};
        }

        public override bool AmReady()
        {
            throw new System.NotImplementedException();
        }
    }


}