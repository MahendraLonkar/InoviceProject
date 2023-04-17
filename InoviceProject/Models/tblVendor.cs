using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InoviceProject.Models
{
    public class tblVendor
    {
        [Key]
        public int Vendor_id { get; set; }
        public string Vendor_name { get; set;}
        public string Firm_name { get; set;}
        public string Firm_address { get; set;}

        [Required]
        [ForeignKey("Locations")]
        public int Location_id { get; set; }
        public virtual tblLocation Locations { get; set; }
        public string Mobile_number { get; set; }
        public string Alternate_number { get; set; }
        public string Email_address { get; set; }
        public int Flag { get; set; }

        public virtual ICollection<tblOrder_details> OrderDetails { get; set; }


    }
}
