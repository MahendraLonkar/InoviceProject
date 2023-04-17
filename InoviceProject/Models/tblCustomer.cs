using System.ComponentModel.DataAnnotations;

namespace InoviceProject.Models
{
    public class tblCustomer
    {
        [Key]
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public string mobile_number { get; set; }
        public int Flag { get; set; }

        public virtual ICollection<tblInvoice_details> Invoice_Details { get; set; }

    }
}
