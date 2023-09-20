using System.Configuration;

namespace TestCases.Utilities;

public class ConfigReader
{
    public static string GetBaseUrl()
    {
        return ConfigurationManager.AppSettings["BaseUrl"];
    }
}