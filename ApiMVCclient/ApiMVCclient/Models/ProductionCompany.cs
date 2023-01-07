using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMVCclient.Models
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
