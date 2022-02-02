using PickPoints.Core.Entities;

namespace PickPoints.Core.Models
{
    public class OrderResponse
    {
        public string[] Goods { get; set; }

        public decimal Cost { get; set; }

        public string RecipientPhone { get; set; }

        public string RecipientFullname { get; set; }

        public string PostampNumber { get; set; }

        public OrderStatus Status { get; set; }
    }
}
