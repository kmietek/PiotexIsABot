using System.Windows.Forms;
using smallData.Factories.PageFactory.Abstract;

namespace smallData.Factories.PageFactory.Pages
{
    public class Likes : PageInfo
    {
        public override bool GetData(WebBrowser page)
        {
            return true;
        }
        public override object getObj()
        {
            return this;
        }
    }
}