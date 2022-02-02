using System.ComponentModel.DataAnnotations;

namespace PickPoints.Core.Entities
{
    public class Order : BaseEntity
    {
        public string[] Goods { get; set; }

        public OrderStatus Status { get; set; }

        public decimal Cost { get; set; }

        [Required]
        public string RecipientPhone { get; set; }

        [Required]
        public string RecipientFullname { get; set; }

        [Required]
        public Postamp Postamp { get; set; }
    }
}
