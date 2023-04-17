using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InoviceProject.Models
{
    public class tblSubCategory
    {
        [Key]
        public int SubCategory_id { get; set; }
        public string SubCategory_name { get; set;}

        [Required]
        [ForeignKey("Categories")]
        public int Category_id { get; set; }
        public virtual tblCategory Categories { get; set; } = null!;
        public int Flag { get; set; }

        public virtual ICollection<tblProduct> Products { get; set; }
    }
}
