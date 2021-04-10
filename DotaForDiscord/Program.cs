using DotaForDiscord.Services;
using MySql.Data.MySqlClient;
using System;
using System.Threading;
using Timer = System.Timers.Timer;

namespace DotaForDiscord
{
    internal class Program
    {
        private static readonly ManualResetEvent quitEvent = new ManualResetEvent(false);

        /// <summary>
        /// dotnet publish -c release --self-contained --runtime linux-x64 --framework netcoreapp3.1
        /// </summary>
        private static void Main(string[] args)
        {
            var timer = new Timer
            {
                Interval = ConfigService.MatchCheckInterval
            };

            timer.Elapsed += (sender, e) =>
            {
                CheckMatches(Log);
            };

            CheckMatches(Log);

            timer.Start();

            Console.CancelKeyPress += (sender, e) =>
            {
                quitEvent.Set();
                e.Cancel = true;
            };

            Console.WriteLine("Running!");

            quitEvent.WaitOne();
        }

        /// <summary>
        /// CREATE TABLE `log` ( `id` INT NOT NULL AUTO_INCREMENT , `timestamp` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP , `message` TEXT NOT NULL , `error` BOOLEAN NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;
        /// </summary>
        /// <param name="message"></param>
        /// <param name="error"></param>
        private static void Log(string message, bool error = false)
        {
            using var connection = new MySqlConnection(ConfigService.MySqlConnectionString);

            connection.Open();

            using var command = new MySqlCommand("INSERT INTO `log`(`message`, `error`) VALUES (@message, @error)", connection);

            command.Parameters.AddWithValue("@message", message);
            command.Parameters.AddWithValue("@error", error);

            command.ExecuteNonQuery();
        }

        private static void CheckMatches(Action<string, bool> log)
        {
            try
            {
                var ids = ServiceManager.LastMatchService.GetTrackedIds();

                foreach (var id in ids)
                {
                    var player = ServiceManager.PlayerService.GetPlayer(id);
                    var lastMatch = ServiceManager.LastMatchService.GetLastMatch(id);

                    foreach (var match in player.LastMatches)
                    {
                        if (match.Id > lastMatch)
                        {
                            log.Invoke($"Discovered new match for player {player.Name}.", false);
                            log.Invoke(Helper.FormatPlayer(player.Name, match), false);

                            WebhookService.PostMessage(Helper.FormatPlayer(player.Name, match), log);

                            ServiceManager.LastMatchService.SetLastMatch(id, match.Id);
                            ServiceManager.LastMatchService.SetName(id, player.Name);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                try
                {
                    WebhookService.PostMessage(e.Message, log, true);
                    WebhookService.PostMessage($"```{e.StackTrace}```", log, true);
                }
                catch (Exception ex)
                {
                    log.Invoke($"Problem posting error message to discord: {ex.Message}. StackTrace: {ex.StackTrace}", true);
                }

                throw;
            }
        }
    }
}