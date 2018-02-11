using System.Collections.Generic;
using System.Windows.Forms;

namespace smallData.Factories.PageFactory.Interfaces
{
    public interface IPage<T>
    {
        List<T> GetData(string document);
        bool AmReady();
    }
}