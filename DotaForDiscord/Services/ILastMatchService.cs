namespace DotaForDiscord.Services
{
    internal interface ILastMatchService
    {
        long GetLastMatch(int id);

        int[] GetTrackedIds();

        void SetLastMatch(int id, long lastMatchId);

        void TrackId(int id);

        void SetName(int id, string name);
    }
}