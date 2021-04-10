using DotaForDiscord.Exceptions;
using DotaForDiscord.Models;
using System;
using System.Collections.Generic;

namespace DotaForDiscord.Services.OpenDota
{
    internal class OpenDotaHeroService : IHeroService
    {
        private readonly Dictionary<int, string> cache;
        private readonly int cacheExpiry;
        private DateTime lastCacheUpdate;

        public OpenDotaHeroService(int cacheExpiry)
        {
            cache = new Dictionary<int, string>();
            this.cacheExpiry = cacheExpiry;
            lastCacheUpdate = DateTime.MinValue;
        }

        public string GetHeroName(int id)
        {
            if ((DateTime.Now - lastCacheUpdate).TotalMilliseconds > cacheExpiry) // Cache expired
            {
                List<HeroModel> heroModels = OpenDotaApiService.GetHeroes();

                cache.Clear();

                foreach (HeroModel hero in heroModels)
                {
                    cache.Add(hero.ID, hero.LocalisedName);
                }

                lastCacheUpdate = DateTime.Now;
            }

            if (cache.ContainsKey(id))
            {
                return cache[id];
            }
            else
            {
                throw new UnknownHeroException(id);
            }
        }
    }
}