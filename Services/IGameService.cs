using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using exam_sample.Models;

namespace exam_sample.Services
{
    public interface IGameService : IService
    {
        public Game Create();
        public List<Game> ListAll();

    }
}
