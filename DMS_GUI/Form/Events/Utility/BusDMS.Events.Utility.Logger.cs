using DMS_Domain.AppConstants;
using DMS_Domain.Enums;

namespace DMS_GUI
{
    public partial class BusDMS
    {
        // Logging
        private void UpdateLogOutput(string message, LogMessageType messageType)
        {
            Color messageColor;
            switch (messageType)
            {
                case LogMessageType.SUCCESS:
                    messageColor = Color.Green;
                    break;
                case LogMessageType.INFO:
                    messageColor = Color.Azure;
                    break;
                case LogMessageType.WARNING:
                    messageColor = Color.Yellow;
                    break;
                case LogMessageType.ERROR:
                    messageColor = Color.Red;
                    break;
                default:
                    messageColor = Color.Azure;
                    break;
            }

            OutputWindow.SelectionStart = OutputWindow.TextLength;
            OutputWindow.SelectionLength = 0;
            OutputWindow.SelectionColor = messageColor;
            OutputWindow.AppendText(message + Environment.NewLine);
            OutputWindow.ScrollToCaret();
        }

        // Search
        private void SearchInOutputWindow(string searchText)
        {
            RemoveHighlights();

            if (string.IsNullOrEmpty(searchText))
            {
                return;
            }

            FindAndHighlightFirstMatch(searchText);
        }

        private void FindAndHighlightFirstMatch(string searchText)
        {
            var startIndex = 0;
            var isFirstMatchFound = false;

            while (startIndex < OutputWindow.TextLength && !isFirstMatchFound)
            {
                var wordStartIndex = FindWordInOutputWindow(searchText, startIndex);
                if (wordStartIndex != -1)
                {
                    HighlightText(wordStartIndex, searchText.Length);
                    isFirstMatchFound = true;
                }
                else
                {
                    _textHandler.ShowWarning(Constants.ItemNotFound + $": {searchText}", "Error");
                    break;
                }
            }

            ResetSelection();
        }

        private int FindWordInOutputWindow(string searchText, int startIndex)
        {
            return OutputWindow.Find(searchText, startIndex, RichTextBoxFinds.None);
        }

        private void ResetSelection()
        {
            OutputWindow.Select(0, 0);
            OutputWindow.SelectionBackColor = OutputWindow.BackColor;
        }

        // Next
        private void FindNext(string searchText)
        {
            if (State.LastSearchIndex >= OutputWindow.TextLength)
            {
                State.LastSearchIndex = 0; // Reset search
            }

            var wordStartIndex = OutputWindow.Find(searchText, State.LastSearchIndex, RichTextBoxFinds.None);
            if (wordStartIndex != -1)
            {
                RemoveHighlights();
                HighlightText(wordStartIndex, searchText.Length);
                State.LastSearchIndex = wordStartIndex + searchText.Length + 1; // Move to right after the current match
            }
            else
            {
                State.LastSearchIndex = 0; // Reset search
            }
        }

        // Previous
        private void FindPrevious(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                return;
            }

            var wordStartIndex = FindPreviousMatch(searchText);

            if (wordStartIndex != -1)
            {
                RemoveHighlights();
                HighlightText(wordStartIndex, searchText.Length);
                State.LastSearchIndex = wordStartIndex;
            }
            else
            {
                State.LastSearchIndex = OutputWindow.TextLength; // No more matches, reset for next cycle
            }
        }

        private int FindPreviousMatch(string searchText)
        {
            var searchEnd = State.LastSearchIndex;
            if (searchEnd <= 0) searchEnd = OutputWindow.TextLength;

            while (searchEnd > 0)
            {
                var wordStartIndex = OutputWindow.Find(searchText, 0, searchEnd, RichTextBoxFinds.Reverse);

                if (wordStartIndex != -1 && wordStartIndex < searchEnd - 1)
                {
                    return wordStartIndex; // Found a match
                }
                searchEnd = wordStartIndex <= 0 ? OutputWindow.TextLength : wordStartIndex;
            }

            return -1; // No match found
        }

        // HighlightColor
        private void HighlightText(int startIndex, int length)
        {
            OutputWindow.Select(startIndex, length);
            DecideHighlightColor();
        }

        private void DecideHighlightColor()
        {
            if (State.IsThemeDark)
            {
                OutputWindow.SelectionBackColor = Color.CadetBlue;
            }
            else
            {
                OutputWindow.SelectionBackColor = Color.Yellow;
            }
        }

        private void RemoveHighlights()
        {
            OutputWindow.SelectAll();
            OutputWindow.SelectionBackColor = OutputWindow.BackColor;
            OutputWindow.DeselectAll();
        }

        // ExpandOrReduce
        private void ExpandOrReduce()
        {
            LoggerSplitContainer.Panel2Collapsed = !LoggerSplitContainer.Panel2Collapsed;

            if (State.IsThemeDark)
            {
                OutputWindowExpandButton.Image = LoggerSplitContainer.Panel2Collapsed ?
                    Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Dark\\dark-lazy.png") :
                    Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Dark\\dark-active.png");
            }
            else
            {
                OutputWindowExpandButton.Image = LoggerSplitContainer.Panel2Collapsed ?
                    Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Light\\light-lazy.png") :
                    Image.FromFile("C:\\Users\\daniel.bus\\source\\repos\\danbus\\srcDMS\\DMS_Project\\Assets\\Light\\light-active.png");
            }
        }
    }
}