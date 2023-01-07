using Microsoft.EntityFrameworkCore;


namespace ApiProject_MovieBlog.Entities
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<ProductionCompany> ProductionCompanies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<MovieType> MovieTypes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Comment> Comments { get; set; }


    }
}
