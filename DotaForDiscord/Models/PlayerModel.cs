#pragma warning disable 0649
using Newtonsoft.Json;

namespace DotaForDiscord.Models
{
    internal class PlayerModel
    {
        [JsonProperty("mmr_estimate")]
        public MMREstimateModel MMREstimate;

        [JsonProperty("profile")]
        public ProfileModel Profile;

        internal class MMREstimateModel
        {
            [JsonProperty("estimate")]
            public int Estimate;
        }

        internal class ProfileModel
        {
            [JsonProperty("account_id")]
            public int AccountID;

            [JsonProperty("avatar")]
            public string Avatar;

            [JsonProperty("personaname")]
            public string PersonaName;

            [JsonProperty("profileurl")]
            public string ProfileURL;

            [JsonProperty("steamid")]
            public long SteamID;
        }
    }
}