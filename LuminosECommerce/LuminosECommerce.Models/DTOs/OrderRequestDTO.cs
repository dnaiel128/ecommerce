namespace LuminosECommerce.Models.DTOs
{
    public class OrderRequestDTO
    {
        public decimal Total { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<ItemQuantityDTO> Items{ get; set; } = new List<ItemQuantityDTO>();
    }
}
