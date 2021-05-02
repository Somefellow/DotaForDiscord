using Discord.Webhook;
using System;
using System.Threading.Tasks;

namespace DotaForDiscord.Services
{
    internal class WebhookService
    {
        public static void PostMessage(string message, Action<string, bool> log, bool error = false)
        {
            using var client = new DiscordWebhookClient(error ? ConfigService.ErrorWebhookURL : ConfigService.WebhookURL);

            client.Log += async arg =>
            {
                log.Invoke(arg.ToString(), false);
            };

            while (message.Length > 0)
            {
                string tempMessage = null;

                if (message.Length >= 1900)
                {
                    tempMessage = message.Substring(0, 1900);
                    message = message.Substring(1900);
                }
                else
                {
                    tempMessage = message;
                    message = string.Empty;
                }

                client.SendMessageAsync(tempMessage).GetAwaiter().GetResult();
            }

        }
    }
}