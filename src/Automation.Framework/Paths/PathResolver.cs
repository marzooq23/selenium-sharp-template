namespace Automation.Framework.Paths;

public static class PathResolver
{
    public static string CreateFolderIfNotExists(this string path)
    {
        DirectoryInfo directoryInfo = new(path);

        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }

        return directoryInfo.FullName;
    }
}