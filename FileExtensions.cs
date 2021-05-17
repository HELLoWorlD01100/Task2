using System.IO;

namespace Task_2
{
    public static class FileExtensions
    {
        public static void ClearFile(string filePath)
        {
            File.WriteAllText(filePath, string.Empty);
        }
    }
}