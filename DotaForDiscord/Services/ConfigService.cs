using System.Configuration;

namespace DotaForDiscord.Services
{
    internal class ConfigService
    {
        public static ulong AdministratorID => ulong.Parse(ConfigurationManager.AppSettings.Get("AdministratorID"));
        public static ulong ChannelID => ulong.Parse(ConfigurationManager.AppSettings.Get("ChannelID"));
        public static string CommandPrefix => ConfigurationManager.AppSettings.Get("CommandPrefix");
        public static string DataFile => ConfigurationManager.AppSettings.Get("DataFile") ?? "data.json";
        public static string DiscordToken => ConfigurationManager.AppSettings.Get("DiscordToken");
        public static int MatchCheckInterval => int.Parse(ConfigurationManager.AppSettings.Get("MatchCheckIntervalMinutes")) * 60000;
        public static string WebhookURL => ConfigurationManager.AppSettings.Get("WebhookURL");
        public static string ErrorWebhookURL => ConfigurationManager.AppSettings.Get("ErrorWebhookURL");
        public static string MySqlConnectionString => ConfigurationManager.AppSettings.Get("MySqlConnectionString");
    }
}