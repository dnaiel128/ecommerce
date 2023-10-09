namespace LuminosECommerce.DAL.Pagination
{
    public class PagedModel<TEntity>
    {
        public const int MaxPageSize = 12;
        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public IList<TEntity> Items { get; set; }

        public PagedModel()
        {
            Items = new List<TEntity>();
        }
    }
}
