using Microsoft.AspNetCore.JsonPatch;
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

        [HttpPatch]
        public IActionResult PatchGame(long id, [FromBody] JsonPatchDocument<Game> patch)
        {
            var game = games.FirstOrDefault(x => x.Id == id);

            if (game is null) return NotFound("Couldn't find a game...");

            //patch.ApplyTo(game, ModelState);

            return Ok(patch);
        }
    }
}
