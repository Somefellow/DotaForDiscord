using DotaForDiscord.Services;
using DotaForDiscord.Services.OpenDota;

namespace DotaForDiscord
{
    /// <summary>
    /// Central location where service implemenetations can be switched out.
    /// </summary>
    internal static class ServiceManager
    {
        public static IHeroService HeroService { get; } = new OpenDotaHeroService(86400000);

        public static IPlayerService PlayerService { get; } = new OpenDotaPlayerService();

        public static ILastMatchService LastMatchService { get; } = new LastMatchMySqlService(ConfigService.MySqlConnectionString);
    }
}