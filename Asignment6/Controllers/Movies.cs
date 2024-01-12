using Asignment6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asignment6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Movies : ControllerBase
    {
        private static readonly List<Movie> movies = new List<Movie>()
        {
            new Movie(){Id=1,title="sholey",genre="drama",rating=8.5},
            new Movie(){Id=2,title="ZNMD",genre="adventure",rating=9},
            new Movie(){Id=3,title="welcome",genre="commedy",rating=7},
            new Movie(){Id=4,title="goalmaal",genre="commedy",rating=8.3},
        };

        [HttpGet(Name = "GetMovies")]
        public IEnumerable<Movie> Get()
        {
            return movies;
        }

        [HttpPost]
        public ActionResult<Movie> Post([FromBody] Movie newMovie)
        {
            if (newMovie == null)
            {
                return BadRequest();
            }

            newMovie.Id = movies.Count + 1; // You may want to use a more sophisticated Id generation mechanism
            movies.Add(newMovie);

            return CreatedAtRoute("GetMovieById", new { id = newMovie.Id }, newMovie);
        }

        [HttpPut("{id}")]
        public ActionResult<Movie> Put(int id, [FromBody] Movie updatedMovie)
        {
            if (updatedMovie == null || id != updatedMovie.Id)
            {
                return BadRequest();
            }

            var existingMovie = movies.FirstOrDefault(m => m.Id == id);

            if (existingMovie == null)
            {
                return NotFound();
            }

            existingMovie.title = updatedMovie.title;
            existingMovie.genre = updatedMovie.genre;
            existingMovie.rating = updatedMovie.rating;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            movies.Remove(movie);

            return NoContent();
        }
    }
}
