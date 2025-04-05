using System.Diagnostics;

namespace Nostalgia.Sync;

static class Program
{
    static void Main()
    {
        var timer = new Stopwatch();
        timer.Start();
        Console.WriteLine($"process started {timer.Elapsed}");

        // read

        // Specify the directory to read
        string directoryPath = "/home/mario/Desktop/nostalgia";

        var paths = new List<string>(){directoryPath};

        for(int i=0; i<paths.Count; i++) 
        {
            var files = Directory.GetFiles(paths[i]);
            foreach (var file in files)
            {
                Console.WriteLine($"\tfound file: {file}");
            }

            var directories = Directory.GetDirectories(paths[i]);
            foreach (var directory in directories)
            {
                paths.Add(directory);
            }
        }

        // hash 

        // persist

        Console.WriteLine($"process finished {timer.Elapsed}");
        timer.Stop();
    }
}