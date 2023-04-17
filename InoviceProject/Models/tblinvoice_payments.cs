using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InoviceProject.Models
{
    public class tblinvoice_payments
    {
        [Key]
        public int payment_id { get; set; }

        [Required]
        [ForeignKey("Invoice_Details")]
        public int invoice_id { get; set; }
        public virtual tblInvoice_details Invoice_Details { get; set; }
        public string payment_date { get; set; }
        public double payment_amount { get; set; }
        public string payment_mode { get; set; }
        public string description { get; set; }

    }
}
