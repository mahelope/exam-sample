using System.Collections.Generic;
using exam_sample.Models;

namespace exam_sample.Cache
{
    public interface IGameCache 
    {
        public Game GetById(string Id);
        public List<Game> ListAll();
        public Game Update(string Id, Game roulette);
        public Game Save(Game game);
    }
}