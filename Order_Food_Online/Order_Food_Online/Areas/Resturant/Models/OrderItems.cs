using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order_Food_Online.Areas.Resturant.Models
{
    public class OrderItems
    {
   
        [ForeignKey("Orders")]
        public int OrderId { get; set; }
        public virtual Orders Orders { get; set; }

        [ForeignKey("Items")]
        public int ItemId { get; set; }
        public virtual Items Items { get; set; }
        public int Quantity { get; set; }


    }
}
