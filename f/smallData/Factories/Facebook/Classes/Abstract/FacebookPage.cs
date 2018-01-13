using System.Collections.Generic;
using System.Windows.Forms;
using Factories.Facebook.Interfaces;

namespace Factories.Facebook.Classes.Abstract
{
    public abstract class FacebookPage : IFacebookPage
    {
        public abstract bool GetData(WebBrowser page);

        public abstract object getObj();

        //public abstract List<BasicClass> GetData(string document);

        //public virtual bool AmReady() => false;
    }
}