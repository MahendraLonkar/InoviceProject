using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InoviceProject.Models
{
    public class tblInvoice_Product
    {
        [Key]
        public int invoice_product_id { get; set; }

        [Required]
        [ForeignKey("Invoice_Details")]
        public int invoice_id { get; set; }
        public virtual tblInvoice_details Invoice_Details { get; set; }

        [Required]
        [ForeignKey("Products")]
        public int product_id { get; set; }
        public virtual tblProduct Products { get; set; }
        public int quantity { get; set; }
        public int Flag { get; set; }

    }
}
