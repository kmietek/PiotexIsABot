using System.Collections.Generic;
using System.Windows.Forms;
using smallData.Facebook.Classes.AbstractClasses;
using smallData.Facebook.Classes.BasicClasses;
using smallData.Factories.PageFactory.Interfaces;

namespace smallData.Factories.PageFactory.Pages
{
    public class About : FacebookPage
    {
        public override List<BasicClass> GetData(string page)
        {
            return new List<BasicClass> { new LikeBasic() };
        }

        public override bool AmReady()
        {
            return false;
        }
    }
}