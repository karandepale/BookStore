using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Order.Entity
{
    public class OrderEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderID { get; set; }
        public long UserID { get; set; }
        public long BookID { get; set; }
        public int BuyQty { get; set; }



        [NotMapped]
        public float OrderAmount { get; set; }


        [NotMapped]
        public BookEntity Book { get; set; }


        [NotMapped]
        public UserEntity User { get; set; }

    }
}
