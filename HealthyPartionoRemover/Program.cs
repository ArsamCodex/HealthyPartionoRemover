using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Specify the disk number and partition number of the recovery partition
        int diskNumber = 0; // Change this to the correct disk number
        int partitionNumber = 6; // Change this to the correct partition number

        // Construct the Diskpart script
        string script = $"select disk {diskNumber}\n" +
                        $"select partition {partitionNumber}\n" +
                        $"delete partition override\n" +
                        $"exit";

        // Create a ProcessStartInfo instance for Diskpart
        ProcessStartInfo psi = new ProcessStartInfo("diskpart.exe")
        {
            UseShellExecute = false,
            RedirectStandardInput = true,
            CreateNoWindow = true
        };

        // Start the Diskpart process
        Process process = Process.Start(psi);

        // Pass the script to Diskpart's standard input
        process.StandardInput.WriteLine(script);
        process.StandardInput.Close();

        // Wait for the process to exit
        process.WaitForExit();

        Console.WriteLine("Recovery partition removed successfully.");
    }
}
