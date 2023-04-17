using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InoviceProject.Models
{
    public class tblInvoice_details
    {
        [Key]
        public int invoice_id { get; set; }
        
        [Required]
        [ForeignKey("Customers")]
        public int customer_id { get; set; }
        public virtual tblCustomer Customers { get; set; }
        public string invoice_date { get; set; }
        public float invoice_amount { get; set; }
        public int Flag { get; set; }
        public virtual ICollection<tblInvoice_Product> Invoice_Products { get; set; }
        public virtual ICollection<tblinvoice_payments> Invoice_Payments { get; set; }
    }
}
