using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMVCclient.Models
{
    public class MovieType
    {
        [Key]
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public int DirectorID { get; set; }

    }
}
