using DotaForDiscord.Exceptions;
using DotaForDiscord.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using DeserializationException = DotaForDiscord.Exceptions.DeserializationException;

namespace DotaForDiscord.Services.OpenDota
{
    /// <summary>
    /// Makes API requests to OpenDota
    /// </summary>
    internal static class OpenDotaApiService
    {
        public static MatchModel[] GetRecentMatches(int player)
        {
            RestClient client = new RestClient("https://api.opendota.com/api");
            RestRequest request = new RestRequest($"players/{player}/recentMatches", Method.GET, DataFormat.Json);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                throw new TooManyRequestsException();
            }
            else if (response.StatusCode == HttpStatusCode.BadGateway)
            {
                throw new BadGatewayException();
            }
            try
            {
                List<MatchModel> matches = JsonConvert.DeserializeObject<List<MatchModel>>(response.Content);
                return matches.ToArray();
            }
            catch (Exception e)
            {
                throw new DeserializationException(response.Content, e);
            }
        }

        public static PlayerModel GetPlayer(int player)
        {
            RestClient client = new RestClient("https://api.opendota.com/api");
            RestRequest request = new RestRequest($"players/{player}", Method.GET, DataFormat.Json);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                throw new TooManyRequestsException();
            }
            else if (response.StatusCode == HttpStatusCode.BadGateway)
            {
                throw new BadGatewayException();
            }
            try
            {
                PlayerModel playerModel = JsonConvert.DeserializeObject<PlayerModel>(response.Content);
                return playerModel;
            }
            catch (Exception e)
            {
                throw new DeserializationException(response.Content, e);
            }
        }

        public static List<HeroModel> GetHeroes()
        {
            RestClient client = new RestClient("https://api.opendota.com/api");
            RestRequest request = new RestRequest($"heroes", Method.GET, DataFormat.Json);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                throw new TooManyRequestsException();
            }
            else if (response.StatusCode == HttpStatusCode.BadGateway)
            {
                throw new BadGatewayException();
            }
            try
            {
                List<HeroModel> heroModels = JsonConvert.DeserializeObject<List<HeroModel>>(response.Content);
                return heroModels;
            }
            catch (Exception e)
            {
                throw new DeserializationException(response.Content, e);
            }
        }

        public static MatchModel GetMatch(int matchId)
        {
            RestClient client = new RestClient("https://api.opendota.com/api");
            RestRequest request = new RestRequest($"matches/{matchId}", Method.GET, DataFormat.Json);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                throw new TooManyRequestsException();
            }
            else if (response.StatusCode == HttpStatusCode.BadGateway)
            {
                throw new BadGatewayException();
            }
            try
            {
                MatchModel matchModel = JsonConvert.DeserializeObject<MatchModel>(response.Content);
                return matchModel;
            }
            catch (Exception e)
            {
                throw new DeserializationException(response.Content, e);
            }
        }
    }
}