using System.Collections.Generic;
using System.Windows.Forms;
using smallData.Factories.PageFactory.Interfaces;

namespace smallData.Facebook.Classes.AbstractClasses
{
    public abstract class MainAbstractClass : IMain
    {
        //data base connection
        public abstract List<AncillaryAbstractClass> GetData(string document);

        public abstract bool AmReady();

        public abstract bool CanScrool();
    }
}