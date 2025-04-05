using System.Diagnostics;
using System.Security.Cryptography;

namespace Nostalgia.Sync;

static class Program
{
    static async Task Main()
    {
        var timer = new Stopwatch();
        timer.Start();
        Console.WriteLine($"process started {timer.Elapsed}");

        // read
        string directoryPath = "/home/mario/Desktop/nostalgia/scan";

        var paths = new List<string>() { directoryPath };
        int fileCount = 0;
        int directoryCount = 0;

        var tasks = new List<Task>();
        int coreCount = Environment.ProcessorCount;

        for (int i = 0; i < paths.Count; i++)
        {
            var files = Directory.GetFiles(paths[i]);
            foreach (var file in files)
            {

                if (tasks.Count >= coreCount)
                {
                    await Task.WhenAny(tasks);
                    tasks.RemoveAll(t => t.IsCompleted);
                }

                tasks.Add(Task.Run(async () =>
                {
                    Console.WriteLine($"\tfile: {file}");
                    string hash = await ComputeFileHashAsync(file);
                    Console.WriteLine($"\thash: {hash}");
                    Interlocked.Increment(ref fileCount);
                }));
            }

            var directories = Directory.GetDirectories(paths[i]);
            foreach (var directory in directories)
            {
                paths.Add(directory);
                directoryCount++;
            }
        }

        // hash 

        // persist

        await Task.WhenAll(tasks);
        Console.WriteLine($"directory count: {directoryCount}\nfile count: {fileCount}");
        Console.WriteLine($"process finished {timer.Elapsed}");
        timer.Stop();
    }

    static async Task<string> ComputeFileHashAsync(string filePath)
    {
        using (var sha256 = SHA256.Create())
        using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync: true))
        {
            var hashBytes = await sha256.ComputeHashAsync(stream);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }
    }
}