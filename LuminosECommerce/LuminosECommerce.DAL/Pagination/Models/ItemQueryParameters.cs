namespace LuminosECommerce.DAL.Pagination.Models
{
    public class ItemQueryParameters : PageOptions
    {
        public string? Name { get; set; }
        public bool? SortByPriceAscending { get; set; }
        public bool? SortByNumberOfReviewsDescending { get; set; }
        public bool? SortByHighestReviewsDescending { get; set; }
    }
}
