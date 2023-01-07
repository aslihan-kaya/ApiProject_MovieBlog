using ApiProject_MovieBlog.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiProject_MovieBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Company : ControllerBase
    {
        private readonly ApplicationContext _context;
        public Company(ApplicationContext context)
        {
            _context = context;

        }


        [HttpGet]
        public IActionResult GetSp()
        {
            return Ok(_context.ProductionCompanies.ToList());
        }

        //api/products?id=1
        //api/products/1
        [HttpPut("{id}")]
        public IActionResult Updatespr(int id, ProductionCompany company)
        {
            var update = _context.ProductionCompanies.FirstOrDefault(I => I.ID == id);
            update.CompanyName = company.CompanyName;
            update.CompanyManager = company.CompanyManager;
            update.Contact = company.Contact;
          


            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletespr(int id)
        {
            var delete = _context.ProductionCompanies.FirstOrDefault(I => I.ID == id);
            _context.Remove(delete);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPost]
        public IActionResult Addspr(ProductionCompany company)
        {
            _context.Add(company);
            _context.SaveChanges();
            return Created("", company);
        }

        //api/products/GetsprById/1
        [HttpGet("{id}")]
        public IActionResult GetsprById(int id)
        {
            return Ok(_context.ProductionCompanies.FirstOrDefault(I => I.ID == id));
        }
    }
}

