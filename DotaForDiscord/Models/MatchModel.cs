#pragma warning disable 0649
using Newtonsoft.Json;

namespace DotaForDiscord.Models
{
    internal class MatchModel
    {
        [JsonProperty("assists")]
        public int Assists;

        [JsonProperty("deaths")]
        public int Deaths;

        [JsonProperty("duration")]
        public int Duration;

        [JsonProperty("game_mode")]
        public int GameMode;

        [JsonProperty("hero_id")]
        public int HeroID;

        [JsonProperty("kills")]
        public int Kills;

        [JsonProperty("lobby_type")]
        public int LobbyType;

        [JsonProperty("match_id")]
        public long MatchID;

        [JsonProperty("player_slot")]
        public int PlayerSlot;

        [JsonProperty("radiant_win")]
        public bool RadiantWin;
    }
}