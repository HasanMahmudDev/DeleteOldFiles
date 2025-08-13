using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Load configuration
        var config = LoadConfig("config.txt");

        if (!config.ContainsKey("FolderPath"))
        {
            Console.WriteLine("Error: FolderPath is missing in config file.");
            return;
        }

        // Read multiple folder paths, handle spaces and quotes
        string[] folderPaths = config["FolderPath"]
            .Split(',')
            .Select(p => p.Trim().Trim('"')) // remove spaces and quotes
            .ToArray();

        // Read previousDays from config
        int previousDays = 0;
        if (config.ContainsKey("previousDays"))
        {
            int.TryParse(config["previousDays"], out previousDays);
        }

        // Calculate threshold date
        DateTime thresholdDate = DateTime.Today.AddDays(-previousDays);

        foreach (string folderPath in folderPaths)
        {
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"Error: Folder '{folderPath}' does not exist.");
                continue;
            }

            Console.WriteLine($"\nCleaning folder: {folderPath}");

            string[] files = Directory.GetFiles(folderPath);

            foreach (string file in files)
            {
                try
                {
                    DateTime modifiedDate = File.GetLastWriteTime(file).Date;

                    // Delete files older than threshold
                    if (modifiedDate < thresholdDate)
                    {
                        File.Delete(file);
                        Console.WriteLine($"Deleted: {Path.GetFileName(file)} (Modified: {modifiedDate:yyyy-MM-dd})");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting {Path.GetFileName(file)}: {ex.Message}");
                }
            }
        }

        Console.WriteLine($"\nOld files deleted successfully (files older than {previousDays} days).");
    }

    // Function to load config file into dictionary
    static Dictionary<string, string> LoadConfig(string configFilePath)
    {
        var config = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        if (File.Exists(configFilePath))
        {
            foreach (var line in File.ReadAllLines(configFilePath))
            {
                if (string.IsNullOrWhiteSpace(line) || line.Trim().StartsWith("#"))
                    continue;

                var parts = line.Split('=', 2);
                if (parts.Length == 2)
                {
                    config[parts[0].Trim()] = parts[1].Trim();
                }
            }
        }
        else
        {
            Console.WriteLine($"Config file '{configFilePath}' not found.");
        }

        return config;
    }
}
