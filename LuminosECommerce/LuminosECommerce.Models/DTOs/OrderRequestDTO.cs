namespace LuminosECommerce.Models.DTOs
{
    public class OrderRequestDTO
    {
        public decimal Total { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<int> ItemsIds{ get; set; } = new List<int>();
    }
}
