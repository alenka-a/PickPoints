namespace PickPoints.Core.Models
{
    public class UpdateOrderRequest
    {
        public string[] Goods { get; set; }

        public decimal Cost { get; set; }

        public string RecipientPhone { get; set; }

        public string RecipientFullname { get; set; }
    }
}
