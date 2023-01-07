using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProject_MovieBlog.Entities
{
    public class Director
    {
        [Key]
        public int DirectorID { get; set; }
        [Required]
        public string DirectorName { get; set; }
       
        public string Awards { get; set; }
        [Required]
        public string Contact { get; set; }
        public int ID { get; set; }
        [ForeignKey("ID")]
        public ProductionCompany Company { get; set; }
    }
}
