using System.ComponentModel.DataAnnotations;

namespace ApiProject_MovieBlog.Entities
{
    public class ProductionCompany
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyManager { get; set; }
        [Required]
        public string Contact { get; set; }

       
    }
}
