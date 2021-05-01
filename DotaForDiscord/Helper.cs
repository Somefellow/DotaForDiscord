using System;
using static DotaForDiscord.Player;

namespace DotaForDiscord
{
    internal static class Helper
    {
        public static string FormatDuration(int duration)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(duration);

            return $"{Math.Floor(timeSpan.TotalMinutes)}:{timeSpan.Seconds}";
        }

        public static string FormatPlayer(string name, RecentMatch match)
        {
            return $"{name} | {match.Hero} | {match.LobbyType} | {match.GameMode} | **{(match.Win ? "Win" : "Loss")}** | {match.Duration} | {match.Kills}/{match.Deaths}/{match.Assists}";
        }

        public static string GameModeToString(int id)
        {
            try
            {
                return Constants.GameModes[id];
            }
            catch
            {
                return "Unknown";
            }
        }

        public static string LobbyTypeToString(int id)
        {
            try
            {
                return Constants.LobbyType[id];
            }
            catch
            {
                return "Unknown";
            }
        }

        public static bool Win(int playerSlot, bool radiantWin)
        {
            return (playerSlot < 128 && radiantWin) || (playerSlot >= 128 && !radiantWin);
        }
    }
}