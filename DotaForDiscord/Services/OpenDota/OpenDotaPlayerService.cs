using System.Collections.Generic;

namespace DotaForDiscord.Services.OpenDota
{
    internal class OpenDotaPlayerService : IPlayerService
    {
        public Player GetPlayer(int id)
        {
            var playerModel = OpenDotaApiService.GetPlayer(id);
            var recentMatchModels = OpenDotaApiService.GetRecentMatches(id);

            if (recentMatchModels == null || recentMatchModels.Length == 0) return null;

            var matches = new List<Player.RecentMatch>();

            foreach (var matchModel in recentMatchModels)
            {
                matches.Insert(0, new Player.RecentMatch(
                   assists: matchModel.Assists,
                   deaths: matchModel.Deaths,
                   duration: Helper.FormatDuration(matchModel.Duration),
                   gameMode: Helper.GameModeToString(matchModel.GameMode),
                   hero: ServiceManager.HeroService.GetHeroName(matchModel.HeroID),
                   id: matchModel.MatchID,
                   kills: matchModel.Kills,
                   lobbyType: Helper.LobbyTypeToString(matchModel.LobbyType),
                   win: Helper.Win(matchModel.PlayerSlot, matchModel.RadiantWin)
               ));
            }

            return new Player(
                playerModel.Profile.AccountID,
                playerModel.Profile.PersonaName,
                matches.ToArray()
            );
        }
    }
}