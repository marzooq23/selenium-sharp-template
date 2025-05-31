namespace SeleniumSharpTemplate.Utilities.Executors;

public static class ProcessRunner
{
    public static void RunBatchFile(string fileNameWithPath, string fileWorkingDirectory)
    {
        Process process = new();
        process.StartInfo.FileName = fileNameWithPath;
        process.StartInfo.WorkingDirectory = fileWorkingDirectory;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.OutputDataReceived += (sender, data) => Console.WriteLine(data.Data);
        process.ErrorDataReceived += (sender, data) => Console.WriteLine(data.Data);
        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        process.WaitForExit();
    }
}