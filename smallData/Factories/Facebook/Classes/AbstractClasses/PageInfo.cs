using System.Windows.Forms;
using smallData.Factories.PageFactory.Interfaces;

namespace smallData.Factories.PageFactory.Abstract
{
    public abstract class PageInfo : IPage
    {
        public abstract bool GetData(WebBrowser page);

        public abstract object getObj();
        //data base connection
    }
}