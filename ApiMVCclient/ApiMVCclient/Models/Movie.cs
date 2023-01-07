using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMVCclient.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }
        [Required]
        public string MovieName { get; set; }
       
        public string MovieDirector { get; set; }
        [Required]
        public string MovieScenarist { get; set; }

        [StringLength(10, ErrorMessage = "Film Puanı 1 ile 10 arasında bir değer almalıdır", MinimumLength = 1)]
        public int MovieRating { get; set; }
        public int TypeID { get; set; }
    }
}
