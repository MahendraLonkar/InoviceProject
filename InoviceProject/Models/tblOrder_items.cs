using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InoviceProject.Models
{
    public class tblOrder_items
    {
        [Key]
        public int orderitem_id { get; set; }

        [Required]
        [ForeignKey("OrderDetails")]
        public int order_id { get; set; }
        public virtual tblOrder_details OrderDetails { get; set; }

        [Required]
        [ForeignKey("Products")]
        public int Product_id { get; set; }
        public virtual tblProduct Products { get; set; }
        public int Order_quantity { get; set; }
         public int Flag { get; set; }

        public virtual ICollection<tblReceived_Items> ReceivedItems { get; set; }
    }
}
