using DMS_Domain.Args;

namespace DMS_GUI
{
    public partial class BusDMS
    {
        private void Logger_MessageLogged(object sender, LogMessageEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateLogOutput(e.Message, e.MessageType)));
            }
            else
            {
                UpdateLogOutput(e.Message, e.MessageType);
            }
        }


        private void OutputWindowClearButton_Click(object sender, EventArgs e)
        {
            OutputWindow.Clear();
        }

        private void OutputWindowSearchButton_Click(object sender, EventArgs e)
        {
            string searchText = OutputWindowSearchField.Text;
            SearchInOutputWindow(searchText);
        }

        private void OutputWindowNextButton_Click(object sender, EventArgs e)
        {
            string searchText = OutputWindowSearchField.Text;
            FindNext(searchText);
        }

        private void OutputWindowPrevButton_Click(object sender, EventArgs e)
        {
            string searchText = OutputWindowSearchField.Text;
            FindPrevious(searchText);
        }

        private void OutputWindowExpandButton_Click(object sender, EventArgs e)
        {
            ExpandOrReduce();
        }
    }
}