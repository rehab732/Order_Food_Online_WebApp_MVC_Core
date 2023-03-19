using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order_Food_Online.Areas.Resturant.Models
{
    public class OrderItems
    {
   
        [ForeignKey("Orders")]
        public int OrderId { get; set; }
        public Orders Order { get; set; }

        [ForeignKey("Items")]
        public int ItemId { get; set; }
        public Items Item { get; set; }
        public int Quantity { get; set; }


    }
}
