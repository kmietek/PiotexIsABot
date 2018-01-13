using System.Collections.Generic;
using System.Windows.Forms;

namespace smallData.Factories.PageFactory.Interfaces
{
    public interface IPage
    {
        List<T> GetData<T>(string page);
        bool AmReady();
    }
}