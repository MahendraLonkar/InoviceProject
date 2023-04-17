using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InoviceProject.Models
{
    public class tblReceived_Items
    {
        [Key]
        public int received_item_id { get; set; }
        [Required]
        [ForeignKey("ReceivedDetails")]
        public int Receive_id { get; set; }
        public virtual tblReceived_details ReceivedDetails { get; set; }
        [Required]
        [ForeignKey("OrderItems")]
        public int orderitem_id { get; set; }
        public virtual tblOrder_items OrderItems { get; set; }
        public int received_quantity { get; set; }
        public float Purchase_rate { get; set; }

        public int flag { get; set; }
    }
}
