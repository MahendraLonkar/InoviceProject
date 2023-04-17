using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InoviceProject.Models
{
    public class tblOrder_details
    {
        [Key]
        public int order_id { get; set; }

        [Required]
        [ForeignKey("Vendors")]
        public int vendor_id { get; set; }
        public virtual tblVendor Vendors { get; set; }
        public string order_date { get; set; }
        public bool Is_Received { get; set; }

        public virtual ICollection<tblOrder_items> OrderItems { get; set; }
        public virtual ICollection<tblReceived_details> ReceivedDetails { get; set; }

    }
}
