using System.ComponentModel.DataAnnotations;

namespace InoviceProject.Models
{
    public class tblCompanyDetails
    {
        [Key]
        public int company_id { get; set; }
        public string company_name { get; set; }
        public string address { get; set; }
        public string mobile_number { get; set; }
        public string email_address { get; set; }
        public string gst_number { get; set; }

    }
}
