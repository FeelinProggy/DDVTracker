using System.Diagnostics;

public class AzuriteController
{
    private Process _azuriteProcess;

    public void Start()
    {
        var filePath = Environment.ExpandEnvironmentVariables(@"%APPDATA%\Roaming\npm\azurite");
        Console.WriteLine($"Resolved path: {filePath}");

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("The specified executable was not found.", filePath);
        }

        var startInfo = new ProcessStartInfo
        {
            FileName = filePath,
            Arguments = "--silent --location ./azurite --debug ./azurite/debug.log",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        _azuriteProcess = Process.Start(startInfo);
    }

    public void Stop()
    {
        if (_azuriteProcess != null && !_azuriteProcess.HasExited)
        {
            _azuriteProcess.Kill();
        }
    }
}
