using ApiProject_MovieBlog.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiProject_MovieBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public DirectorController(ApplicationContext context)
        {
            _context = context;

        }


        [HttpGet]
        public IActionResult GetSp()
        {
            return Ok(_context.Directors.ToList());
        }

        //api/products?id=1
        //api/products/1
        [HttpPut("{id}")]
        public IActionResult Updatespr(int id, Director director)
        {
            var update = _context.Directors.FirstOrDefault(I => I.DirectorID == id);
            update.DirectorName = director.DirectorName;
            update.Awards = director.Awards;
            update.Contact = director.Contact;
            update.ID = director.ID;
          
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletespr(int id)
        {
            var delete = _context.Directors.FirstOrDefault(I => I.ID == id);
            _context.Remove(delete);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPost]
        public IActionResult Addspr(Director director)
        {
            _context.Add(director);
            _context.SaveChanges();
            return Created("", director);
        }

        //api/products/GetsprById/1
        [HttpGet("{id}")]
        public IActionResult GetsprById(int id)
        {
            return Ok(_context.Directors.FirstOrDefault(I => I.ID == id));
        }
    }
}

