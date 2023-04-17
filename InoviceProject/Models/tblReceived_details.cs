using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InoviceProject.Models
{
    public class tblReceived_details
    {
        [Key]
        public int Receive_stock_id { get; set; }

        [Required]
        [ForeignKey("OrderDetails")]
        public int Order_id { get; set; }
        public virtual tblOrder_details OrderDetails { get; set; }
        public string Received_date { get; set; }
        public int Flag { get;set; }
        

        public virtual ICollection<tblReceived_Items> ReceivedItems { get; set;}
    }
}
