using System.ComponentModel.DataAnnotations;

namespace InoviceProject.Models
{
    public class tblLocation
    {
        [Key]
        public int Location_id { get; set; }
        public string Location_name { get; set; }

        public virtual ICollection<tblVendor> Vendors { get; set; }
    }
}
