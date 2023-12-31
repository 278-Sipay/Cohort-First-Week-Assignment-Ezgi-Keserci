﻿using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestfulApi.Models;
using System.Collections.Generic;
using System.Net;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestfulApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private static List<Game> games = GameLibrary.gameList;

        // GET: api/<GamesController>
        [HttpGet]
        public List<Game> GetGames()
        {
            return games;
        }

        // GET api/<GamesController>/5
        [HttpGet("{id}")]
        public ActionResult<Game> Get(int id)
        {
            var game = games.FirstOrDefault(x => x.Id == id);

            if (game is null)
                return NotFound("Böyle bir oyun bulunamadı...");

            return game;
        }

        [HttpGet("GetByParameterQuery")]
        public ActionResult<Game> GetByParamenterQuery([FromQuery] int? id, [FromQuery] string? name)
        {
            var gameById = games.FirstOrDefault(x => x.Id == id);
            if (gameById is null)
            {
                var gameByName = games.First(x => x.Name == name);
                if (gameByName is null)
                {
                    return NotFound("Aradığınız oyun bulunamadı...");
                }
                return gameByName;
            }
            return gameById;
        }

        // POST api/<GamesController>
        [HttpPost]
        public ActionResult<Game> Post([FromBody] Game gameContext)
        {
            var game = games.FirstOrDefault(x => x.Name == gameContext.Name);

            if (game is not null)
            {
                return BadRequest("Böyle bir oyun zaten var!");
            }

            games.Add(gameContext);
            return StatusCode(201, "Oyun listeye eklendi...");
        }

        // PUT api/<GamesController>/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody] Game gameContext)
        {
            var game = games.FirstOrDefault(x => x.Id == id);

            if (game is null)
            {
                return NotFound("Böyle bir oyun bulunamadı...");
            }

            game.Name = gameContext.Name != default ? gameContext.Name : game.Name;
            game.Description = gameContext.Description != default ? gameContext.Description : game.Description;
            game.Genre = gameContext.Genre != default ? gameContext.Genre : game.Genre;
            game.Developer = gameContext.Developer != default ? gameContext.Developer : game.Developer;
            game.Publisher = gameContext.Publisher != default ? gameContext.Publisher : game.Publisher;
            game.ReleaseDate = gameContext.ReleaseDate != default ? gameContext.ReleaseDate : game.ReleaseDate;
            game.Platform = gameContext.Platform != default ? gameContext.Platform : game.Platform;
            game.Price = gameContext.Price != default ? gameContext.Price : game.Price;

            return Ok("Oyun bilgileri güncellendi");
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var game = games.FirstOrDefault(x => x.Id == id);

            if (game is null)
                return NotFound("Böyle bir oyun bulunamadı...");

            games.Remove(game);
            return Ok("Oyun silindi.");
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateGame(int id, [FromBody] Game updatedGame)
        {
            var game = games.Find(x => x.Id == id);
            if (game is null)
            {
                return NotFound("Böyle bir oyun yok...");
            }

            // Güncelleme işlemleri
            game.Name = updatedGame.Name != null ? updatedGame.Name : game.Name;
            game.Description = updatedGame.Description != null ? updatedGame.Description : game.Description;
            game.Genre = updatedGame.Genre != null ? updatedGame.Genre : game.Genre;
            game.Developer = updatedGame.Developer != null ? updatedGame.Developer : game.Developer;
            game.Publisher = updatedGame.Publisher != null ? updatedGame.Publisher : game.Publisher;
            game.ReleaseDate = updatedGame.ReleaseDate != null ? updatedGame.ReleaseDate : game.ReleaseDate;
            game.Platform = updatedGame.Platform != null ? updatedGame.Platform : game.Platform;
            game.Price = updatedGame.Price != null ? updatedGame.Price : game.Price;

            return Ok(game);
        }


        //--- Ödevdeki bonus görevler ---//

        //Sort by name or genre
        [HttpGet("SortByNameOrGenre")]
        public ActionResult<List<Game>> Sorting([FromQuery] bool? sortByName, [FromQuery] bool? sortByGenre)
        {
            if (sortByName != false)
            {
                games.Sort((x, y) => x.Name.CompareTo(y.Name));
                return Ok(games);
            }

            if (sortByGenre != false)
            {
                games.Sort((x, y) => x.Genre.CompareTo(y.Genre));
                return Ok(games);
            }

            return BadRequest("Sıralama yapılamadı...");
        }

        //List by name
        [HttpGet("ListByName")]
        public IActionResult GetGames([FromQuery] string name)
        {
            IEnumerable<Game> filteredGames = games;

            if (!string.IsNullOrEmpty(name))
            {
                filteredGames = games.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            }

            return Ok(filteredGames);
        }
    }
}
