using DMS_Domain.Interfaces.HelperInterfaces;

namespace DMS_BLL.Helpers.Formatters
{
    public class Formatter : IFormatter
    {
        public string FormatBytes(long bytes)
        {
            string[] suffixes = { "B", "KB", "MB", "GB", "TB", "PB" };
            var counter = 0;
            var number = (decimal)bytes;

            while (Math.Round(number / 1024) >= 1)
            {
                number /= 1024;
                counter++;
            }

            return string.Format("{0:n1} {1}", number, suffixes[counter]);
        }
    }
}