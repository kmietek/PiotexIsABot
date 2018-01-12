using System.Windows.Forms;
using smallData.Factories.PageFactory.Abstract;
using smallData.Factories.PageFactory.Interfaces;

namespace smallData.Factories.PageFactory.Pages
{
    public class Localization : PageInfo
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