#pragma warning disable 0649
using Newtonsoft.Json;

namespace DotaForDiscord.Models
{
    internal class HeroModel
    {
        [JsonProperty("id")]
        public int ID;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("localized_name")]
        public string LocalisedName;
    }
}