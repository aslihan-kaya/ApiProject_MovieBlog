using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMVCclient.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        [Required]
        public string MovieName { get; set; }
        [Required]
        public string MovieComment { get; set; }

        public int MovieID { get; set; }
    }
}
