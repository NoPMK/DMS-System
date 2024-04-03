namespace DMS_GUI.Extensions
{
    public static class FileSystemExtensions
    {
        public static string CombineWithFileName(this string path, string fileName)
        {
            return Path.Combine(path, fileName);
        }

        public static string ExtractFileName(this string path)
        {
            return Path.GetFileName(path);
        }

        public static string ExtractExtension(this string path)
        {
            return Path.GetExtension(path);
        }

        public static string HasParentFolder(this string folderPath)
        {
            var dirInfo = new DirectoryInfo(folderPath);
            return dirInfo.Parent?.FullName;
        }
    }
}