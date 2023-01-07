using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProject_MovieBlog.Entities
{
    public class MovieType
    {
        [Key]
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public int DirectorID { get; set; }
        [ForeignKey("DirectorID")]
        public Director Director { get; set; }

    }
}
