using System;
using System.IO;

class Program
{
    static void Main()
    {
        string directoryPath = @"FileCollection";
        string resultsFile = "results.txt";

        int excelCount = 0, wordCount = 0, powerPointCount = 0;
        long excelSize = 0, wordSize = 0, powerPointSize = 0;

        DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

        foreach (var file in directoryInfo.GetFiles())
        {
            if (IsOfficeFile(file.Extension))
            {
                if (file.Extension == ".xlsx")
                {
                    excelCount++;
                    excelSize += file.Length;
                }
                else if (file.Extension == ".docx")
                {
                    wordCount++;
                    wordSize += file.Length;
                }
                else if (file.Extension == ".pptx")
                {
                    powerPointCount++;
                    powerPointSize += file.Length;
                }
            }
        }

        using (StreamWriter writer = new StreamWriter(resultsFile))
        {
            writer.WriteLine("Microsoft Office Files Summary:");
            writer.WriteLine($"Excel Files: {excelCount} files, Total Size: {excelSize} bytes");
            writer.WriteLine($"Word Files: {wordCount} files, Total Size: {wordSize} bytes");
            writer.WriteLine($"PowerPoint Files: {powerPointCount} files, Total Size: {powerPointSize} bytes");
        }
    }

    static bool IsOfficeFile(string extension)
    {
        return extension == ".xlsx" || extension == ".docx" || extension == ".pptx";
    }
}