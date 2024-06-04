using System.IO;
using System;
using System.Threading.Tasks;

public class FileService : IFileService
{
    private void CheckLocalDirectory()
    {
        string path = @"C:\Users\macavall\LargeFiles\";

        if (Directory.Exists(path))
        {
            Console.WriteLine("That path exists already: " + path);
        }
        else
        {
            Console.WriteLine("That path does not exist: " + path + "\r\nCreating the Directoy now!");

            Directory.CreateDirectory(@"C:\home\LogFiles\LargeFiles\");
        }
    }

    public async Task WriteFile()
    {
        await Task.Delay(1);

        CheckLocalDirectory();

        // Get the current date-time ticks value
        string directoryName = DateTime.Now.Ticks.ToString();
        string defaultPath = @"C:\home\LogFiles\LargeFiles\";
        string directoryPath = String.Empty;

        if (Directory.Exists(defaultPath))
        {
            Console.WriteLine("That path exists already.");

            directoryPath = Path.Combine(@"C:\home\LogFiles\LargeFiles\", directoryName);
        }
        else
        {
            Console.WriteLine("That path does not exist.");

            directoryPath = Path.Combine(@"C:\Users\macavall\LargeFiles\", directoryName);
        }
        
        // Create the directory
        Directory.CreateDirectory(directoryPath);

        // Define the file path within the created directory
        string filePath = Path.Combine(directoryPath, "largefile_" + directoryName + ".txt");
        long fileSizeInBytes = 2L * 1024 * 1024 * 1024; // 2 Gigabytes
        byte[] buffer = new byte[1024 * 1024]; // 1 Megabyte buffer
        long bytesWritten = 0;

        // Initialize buffer with data (e.g., all zeros)
        for (int i = 0; i < buffer.Length; i++)
        {
            buffer[i] = 0;
        }

        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, buffer.Length, FileOptions.SequentialScan))
        {
            while (bytesWritten < fileSizeInBytes)
            {
                fs.Write(buffer, 0, buffer.Length);
                bytesWritten += buffer.Length;
            }
        }
    }

    public async Task WriteFile(int loopNumber)
    {
        await Task.Delay(1);

        for (int x = 0; x < loopNumber; x++)
        {
            await WriteFile();
        }
    }

    public async Task DeleteFile()
    {
        await Task.Delay(1);

        string defaultPath = @"C:\home\LogFiles\LargeFiles\";

        if (Directory.Exists(defaultPath))
        {
            Console.WriteLine("That path exists already.");

            // delete directory and subdirectories
            Directory.Delete(defaultPath, true);
        }
        else
        {
            Console.WriteLine("That path does not exist.");

            // delete directory and subdirectories
            Directory.Delete(@"C:\Users\macavall\LargeFiles\", true);
        }
    }
}