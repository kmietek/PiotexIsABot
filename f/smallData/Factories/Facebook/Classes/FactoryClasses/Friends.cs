using System.Collections.Generic;
using System.Windows.Forms;
using Factories.Facebook.Classes.Abstract;
using Factories.Facebook.Classes.BasicClasses;

namespace Factories.Facebook.Classes.FactoryClasses
{
    public class Friends : FacebookPage
    {
//        public override bool AmReady()
//        {
//            return base.AmReady();
//        }

//        public override List<BasicClass> GetData(string document)
//        {
//            return new List<BasicClass>
//            {
//                new Like(),
//            };
//        }

        public override bool GetData(WebBrowser page)
        {
            throw new System.NotImplementedException();
        }

        public override object getObj()
        {
            throw new System.NotImplementedException();
        }
    }
}