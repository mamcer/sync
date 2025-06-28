using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Cookbook.Data;
using Nostalgia.Application;
using Nostalgia.Core.Entities;
using Nostalgia.Data;

namespace Nostalgia.Sync;

/// <summary>
/// Main entry point for the Nostalgia.Sync application.
/// </summary>
internal static class Program
{
    private const string DefaultDirectoryPath = "/home/mario/Desktop/nostalgia/scan";
    private const int DefaultScanId = 99;

    /// <summary>
    /// Application entry point.
    /// </summary>
    public static async Task Main()
    {
        var timer = new Stopwatch();
        timer.Start();
        Console.WriteLine($"Process started {timer.Elapsed}");

        var paths = new List<string> { DefaultDirectoryPath };
        int fileCount = 0;
        int directoryCount = 0;
        var tasks = new List<Task>();
        int coreCount = Environment.ProcessorCount;

        for (int i = 0; i < paths.Count; i++)
        {
            string currentPath = paths[i];
            string[] files = Array.Empty<string>();
            string[] directories = Array.Empty<string>();
            try
            {
                files = Directory.GetFiles(currentPath);
                directories = Directory.GetDirectories(currentPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing {currentPath}: {ex.Message}");
                continue;
            }

            foreach (var file in files)
            {
                if (tasks.Count >= coreCount)
                {
                    await Task.WhenAny(tasks);
                    tasks.RemoveAll(t => t.IsCompleted);
                }

                tasks.Add(ProcessFileAsync(file, () => Interlocked.Increment(ref fileCount)));
            }

            foreach (var directory in directories)
            {
                paths.Add(directory);
                directoryCount++;
            }
        }

        await Task.WhenAll(tasks);
        Console.WriteLine($"Directory count: {directoryCount}\nFile count: {fileCount}");
        Console.WriteLine($"Process finished {timer.Elapsed}");
        timer.Stop();
    }

    /// <summary>
    /// Processes a single file: computes its hash and persists its metadata.
    /// </summary>
    private static async Task ProcessFileAsync(string file, Action incrementFileCount)
    {
        try
        {
            Console.WriteLine($"\tFile: {file}");
            string hash = await ComputeFileHashAsync(file);
            Console.WriteLine($"\tHash: {hash}");
            incrementFileCount();

            var cosa = new Cosa
            {
                Name = Path.GetFileName(file),
                Path = file,
                Hash = hash,
                ScanId = DefaultScanId
            };

            // In a real application, use dependency injection for these services
            using var entities = new NostalgiaEntities();
            var cosaService = new CosaService(new EntityFrameworkUnitOfWork(entities), new CosaRepository(entities));
            cosaService.AddCosa(cosa);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing file {file}: {ex.Message}");
        }
    }

    /// <summary>
    /// Computes the SHA256 hash of a file asynchronously.
    /// </summary>
    private static async Task<string> ComputeFileHashAsync(string filePath)
    {
        using var sha256 = SHA256.Create();
        using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync: true);
        var hashBytes = await sha256.ComputeHashAsync(stream);
        return BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLowerInvariant();
    }
}