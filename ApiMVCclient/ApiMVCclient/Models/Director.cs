using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMVCclient.Models
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
    }
}
