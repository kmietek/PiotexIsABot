using System.Collections.Generic;
using System.Windows.Forms;
using smallData.Facebook.Classes.AbstractClasses;

namespace smallData.Factories.PageFactory.Interfaces
{
    public interface IMain
    {
        List<AncillaryAbstractClass> GetData(string document);
        bool AmReady();
        bool CanScrool();
    }
}