using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InoviceProject.Models
{
    public class tblProduct
    {
        [Key]
        public int Product_id { get; set; }
        public string Product_name { get; set; }

        [Required]
        [ForeignKey("SubCategories")]
        public int SubCategory_id { get; set; }
        public virtual tblSubCategory SubCategories { get; set; }
        public float Weight { get; set; }

        [Required]
        [ForeignKey("Units")]
        public int Unit_id { get; set; }
        public virtual tblUnit Units { get; set; }
        public int Stock_quantity { get; set; }
        public float Selling_rate { get; set; }
        public float Tax { get; set; }
        public int flag { get; set; }
        public virtual ICollection<tblOrder_items> OrderItems { get; set; }
        public virtual ICollection<tblInvoice_Product> Invoice_Products { get; set; }



    }
}
