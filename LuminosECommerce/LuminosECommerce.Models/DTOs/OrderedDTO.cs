namespace LuminosECommerce.Models.DTOs
{
    public class OrderedDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public ItemDTO? Item { get; set; }
    }
}
