using System;
using System.Collections.Generic;
using System.Linq;
using EasyCaching.Core;
using exam_sample.Models;

namespace exam_sample.Cache
{
    public class GameCache : IGameCache
    {
        private IEasyCachingProviderFactory cachingProviderFactory;
        private IEasyCachingProvider cachingProvider;
        private const string KEYREDIS = "ROULETEGAME";
        public GameCache(IEasyCachingProviderFactory cachingProviderFactory)
        {
            this.cachingProviderFactory = cachingProviderFactory;
            this.cachingProvider = this.cachingProviderFactory.GetCachingProvider("game");
        }
        public Game GetById(string Id)
        {
            var item = this.cachingProvider.Get<Game>(KEYREDIS + Id);
            if (!item.HasValue)
            {
                return null;
            }
            return item.Value;
        }
        public List<Game> ListAll()
        {
            var game = this.cachingProvider.GetByPrefix<Game>(KEYREDIS);
            if (game.Values.Count == 0)
            {
                return new List<Game>();
            }
            return new List<Game>(game.Select(x => x.Value.Value));
        }
        public Game Update(string Id, Game game)
        {
            game.Id = Id;
            return Save(game);
        }
        public Game Save(Game game)
        {
            cachingProvider.SetAsync(KEYREDIS + game.Id , game, TimeSpan.FromDays(365));
            return game;
        }
    }
}