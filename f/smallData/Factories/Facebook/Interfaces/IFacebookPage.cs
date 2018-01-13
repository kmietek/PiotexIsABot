using System.Collections.Generic;
using System.Windows.Forms;
using Factories.Facebook.Classes.Abstract;

namespace Factories.Facebook.Interfaces
{
    public interface IFacebookPage
    {
        bool GetData(WebBrowser page);
        //        List<BasicClass> GetData(string document);
    }
}