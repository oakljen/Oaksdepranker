using System;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace Oaksdepranker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Stop the "disconnecter.exe" process
            StopProcessByName("disconnecter");

            // Stop the "prank.exe" process
            StopProcessByName("prank");

            // Wait for the user to press a key before exiting
            Console.WriteLine("Process compleate click enter...");
            Console.ReadKey();
            try
            {
                // Specify the path of the folder to delete
                string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft", "Windows", "Start Menu", "Programs", "Startup", "OaksPranks");
                folderPath = folderPath.Replace("{username}", Environment.UserName);

                // Delete the folder and its contents recursively
                Directory.Delete(folderPath, true);

                Console.WriteLine("The folder has been deleted successfully.");
            }
            catch (Exception ex)
            {
                // Handle the exception and display an error message to the user
                Console.WriteLine("An error occurred while deleting the folder: " + ex.Message);
            }

            // Wait for the user to press a key before exiting
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        static void StopProcessByName(string processName)
        {
            // Get an array of all processes with the specified process name
            Process[] processes = Process.GetProcessesByName(processName);

            // Loop through the processes array to find the process you want to stop
            foreach (Process process in processes)
            {
                try
                {
                    // Stop the process
                    process.Kill();
                    Console.WriteLine($"The {processName} process has been terminated successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while terminating the {processName} process: {ex.Message}");
                }
            }
        }
    }
}
