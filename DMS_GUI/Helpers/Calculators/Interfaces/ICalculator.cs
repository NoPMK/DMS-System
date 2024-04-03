using System.Windows.Forms;

namespace DMS_GUI.Helpers.Calculators.Interfaces
{
    public interface ICalculator
    {
        long CalculateTotalSize(ListView listView);
    }
}