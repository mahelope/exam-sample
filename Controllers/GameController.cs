﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using exam_sample.Models;
using exam_sample.Services;

namespace exam_sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        /// <summary>
        /// Create a new game
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult NewGame()
        {
            Game gameRoulette = gameService.Create();
            return Ok(gameRoulette);
        }

        [HttpGet]
        public IActionResult ListAll()
        {
            return Ok(gameService.ListAll());
        }

    }
}
