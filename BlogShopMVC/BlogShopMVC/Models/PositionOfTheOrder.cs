namespace SklepBlog.Models
{
    public class PositionOfTheOrder
    {
        public int PositionOfTheOrderId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public decimal OrderPrice { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}