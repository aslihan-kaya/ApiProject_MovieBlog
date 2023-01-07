using ApiProject_MovieBlog.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiProject_MovieBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public TypeController(ApplicationContext context)
        {
            _context = context;

        }


        [HttpGet]
        public IActionResult GetSp()
        {
            return Ok(_context.MovieTypes.ToList());
        }

        //api/products?id=1
        //api/products/1
        [HttpPut("{id}")]
        public IActionResult Updatespr(int id, MovieType type)
        {
            var update = _context.MovieTypes.FirstOrDefault(I => I.TypeID == id);
            update.TypeName = type.TypeName;
            update.DirectorID = type.DirectorID;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletespr(int id)
        {
            var delete = _context.MovieTypes.FirstOrDefault(I => I.TypeID == id);
            _context.Remove(delete);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPost]
        public IActionResult Addspr(MovieType type)
        {
            _context.Add(type);
            _context.SaveChanges();
            return Created("", type);
        }

        //api/products/GetsprById/1
        [HttpGet("{id}")]
        public IActionResult GetsprById(int id)
        {
            return Ok(_context.MovieTypes.FirstOrDefault(I => I.TypeID == id));
        }
    }
}

