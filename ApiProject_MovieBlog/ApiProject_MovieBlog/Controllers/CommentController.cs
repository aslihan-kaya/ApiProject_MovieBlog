using ApiProject_MovieBlog.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiProject_MovieBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public CommentController(ApplicationContext context)
        {
            _context = context;

        }


        [HttpGet]
        public IActionResult GetSp()
        {
            return Ok(_context.Comments.ToList());
        }

        //api/products?id=1
        //api/products/1
        [HttpPut("{id}")]
        public IActionResult Updatespr(int id, Comment comment)
        {
            var update = _context.Comments.FirstOrDefault(I => I.CommentID == id);
            update.MovieName = comment.MovieName;
            update.MovieComment = comment.MovieComment;
           
            update.MovieID = comment.MovieID;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletespr(int id)
        {
            var delete = _context.Comments.FirstOrDefault(I => I.CommentID == id);
            _context.Remove(delete);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPost]
        public IActionResult Addspr(Comment comment)
        {
            _context.Add(comment);
            _context.SaveChanges();
            return Created("", comment);
        }

        //api/products/GetsprById/1
        [HttpGet("{id}")]
        public IActionResult GetsprById(int id)
        {
            return Ok(_context.Comments.FirstOrDefault(I => I.CommentID == id));
        }
    }
}
