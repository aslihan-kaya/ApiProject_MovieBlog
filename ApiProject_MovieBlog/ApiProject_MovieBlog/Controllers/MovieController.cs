using ApiProject_MovieBlog.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiProject_MovieBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public MovieController(ApplicationContext context)
        {
            _context = context;

        }


        [HttpGet]
        public IActionResult GetSp()
        {
            return Ok(value:_context.Movies.ToList());
        }

        //api/products?id=1
        //api/products/1
        [HttpPut("{id}")]
        public IActionResult Updatespr(int id, Movie movie)
        {
            var update = _context.Movies.FirstOrDefault(I => I.MovieID == id);
            update.MovieName = movie.MovieName;
            update.MovieDirector = movie.MovieDirector;
            update.MovieScenarist = movie.MovieScenarist;
            update.MovieRating = movie.MovieRating;
            update.TypeID = movie.TypeID;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletespr(int id)
        {
            var delete = _context.Movies.FirstOrDefault(I => I.MovieID == id);
            _context.Remove(delete);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPost]
        public IActionResult Addspr(Movie movie)
        {
            _context.Add(movie);
            _context.SaveChanges();
            return Created("", movie);
        }

        //api/products/GetsprById/1
        [HttpGet("{id}")]
        public IActionResult GetsprById(int id)
        {
            return Ok(_context.Movies.FirstOrDefault(I => I.MovieID == id));
        }
    }
}
