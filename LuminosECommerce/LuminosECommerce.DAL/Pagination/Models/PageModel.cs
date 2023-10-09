namespace LuminosECommerce.DAL.Pagination.Models
{
    public class PageOptions
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int StartRow => (PageIndex - 1) * PageSize;
    }
}
