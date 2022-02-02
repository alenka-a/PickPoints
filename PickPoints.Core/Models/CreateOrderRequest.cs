namespace PickPoints.Core.Models
{
    public class CreateOrderRequest
    {
        public string[] Goods { get; set; }

        public decimal Cost { get; set; }

        public string RecipientPhone { get; set; }

        public string RecipientFullname { get; set; }

        public string PostampNumber { get; set; }
    }
}
