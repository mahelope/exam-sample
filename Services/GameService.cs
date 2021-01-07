using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using exam_sample.Models;
using exam_sample.Cache;


namespace exam_sample.Services
{
    public class GameService : IGameService
    {
        private IGameCache gameCache;

        public GameService(IGameCache gameCache)
        {
            this.gameCache = gameCache;
        }

        public Game Create()
        {
            Game game = new Game()
            {
                Id = Guid.NewGuid().ToString(),
                IsOpen = false
            };
            gameCache.Save(game);
            return game;
        }
        public List<Game> ListAll()
        {
            return gameCache.ListAll();
        }

    }
}
