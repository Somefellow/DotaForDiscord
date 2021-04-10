namespace DotaForDiscord
{
    internal class Player
    {
        public readonly int Id;
        public readonly RecentMatch[] LastMatches;
        public readonly string Name;

        public Player(int id, string name, RecentMatch[] lastMatches)
        {
            Id = id;
            LastMatches = lastMatches;
            Name = name;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        internal class RecentMatch
        {
            public readonly int Assists;
            public readonly int Deaths;
            public readonly string Duration;
            public readonly string GameMode;
            public readonly string Hero;
            public readonly long Id;
            public readonly int Kills;
            public readonly string LobbyType;
            public readonly bool Win;

            public RecentMatch(int assists, int deaths, string duration, string gameMode, string hero, long id, int kills, string lobbyType, bool win)
            {
                Assists = assists;
                Deaths = deaths;
                Duration = duration;
                GameMode = gameMode;
                Hero = hero;
                Id = id;
                Kills = kills;
                LobbyType = lobbyType;
                Win = win;
            }
        }
    }
}