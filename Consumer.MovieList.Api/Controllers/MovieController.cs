using Consumer.MovieList.Api.Domain.Movie.Interface;
using Consumer.MovieList.Api.Domain.Movie.Model;
using Consumer.MovieList.Api.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Consumer.MovieList.Api.Controllers
{
    [ApiController]
    [Route("api/movie")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _movieService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _movieService.GetById(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("awards")]
        public IActionResult GetAwards()
        {
            var result = _movieService.GetAwards();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Save([FromBody] MovieDto movie)
        {
            var id = _movieService.Save(movie);
            return Ok(id);
        }

        [HttpPut]
        public IActionResult Update(int id, [FromBody] MovieDto model)
        {
            var movie = _movieService.Update(id, model);
            return Ok(movie);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            int idMovieDeleted =  _movieService.Delete(id);
            return Ok(idMovieDeleted);
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult Patch(int id, [FromBody] MovieDto model)
        {
            var movie = _movieService.PatchUpdate(id, model);
            return Ok(movie);
        }
    }
}
