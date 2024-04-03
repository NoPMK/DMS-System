using DMS_Domain.AppConstants;
using DMS_GUI.Helpers.Calculators.Interfaces;

namespace DMS_GUI.Helpers.Calculators
{
    public class Calculator : ICalculator
    {
        public long CalculateTotalSize(ListView listView)
        {
            return listView.SelectedItems
                    .OfType<ListViewItem>()
                    .Where(item => item.Text != Constants.FolderUp
                    && item.Name != Constants.Editable
                    && long.TryParse(item.SubItems[2].Text, out _))
                    .Sum(item => long.Parse(item.SubItems[2].Text));
        }
    }
}