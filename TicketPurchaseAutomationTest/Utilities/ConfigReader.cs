using System.Configuration;

namespace TicketPurchaseAutomationTest.Utilities;

public abstract class ConfigReader
{
    public static string? GetBaseUrl()
    {
        try
        {
            const string configFilePath = @"C:\Projects\Repositories\Git\TicketPurchaseAutomationTest\TicketPurchaseAutomationTest\Configuration\config.xml"; 
            var configFileMap = new ExeConfigurationFileMap { ExeConfigFilename = configFilePath };
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            return config.AppSettings.Settings["BaseUrl"].Value;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading config.xml: {ex.Message}");
            return null;
        }
    }

}