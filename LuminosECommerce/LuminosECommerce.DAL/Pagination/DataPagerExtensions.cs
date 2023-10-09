using LuminosECommerce.DAL.Pagination.Models;
using LuminosECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace LuminosECommerce.DAL.Pagination
{
    public static class DataPagerExtensions
    {
        public static async Task<PagedModel<TEntity>> PaginateAsync<TEntity>(this IQueryable<TEntity> query, PageOptions pageOptions)
        {
            var pagedModel = new PagedModel<TEntity>();
            var pageIndex = pageOptions.PageIndex;
            var pageSize = pageOptions.PageSize;

            pageIndex = (pageIndex < 1) ? 1 : pageIndex;
            pageSize = (pageSize < 1) ? PagedModel<TEntity>.MaxPageSize : pageSize;

            pagedModel.CurrentPage = pageIndex;
            pagedModel.PageSize = pageSize;

            pagedModel.TotalItems = await query.CountAsync();
            var paginatedQuery = query.Skip((pagedModel.CurrentPage - 1) * pagedModel.PageSize).Take(pagedModel.PageSize);

            pagedModel.Items = await paginatedQuery!.ToListAsync();
            pagedModel.TotalPages = (int)Math.Ceiling(pagedModel.TotalItems / (double)pagedModel.PageSize);

            return pagedModel;
        }

        /// <summary>
        /// Filter, sort and get paginated list of items.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public static async Task<PagedModel<Item>> PaginateWithFilterAndSortAsync(
            this IQueryable<Item> query, ItemQueryParameters queryParams)
        {
            //filter
            if (!string.IsNullOrEmpty(queryParams.Name))
            {
                query = query.Where(d => d.Name.Contains(queryParams.Name));
            }

            //sort
            if (queryParams.SortByPriceAscending != null)
            {
                if (queryParams.SortByPriceAscending == true)
                {
                    query = query.OrderBy(d => d.Price);
                }
                else
                {
                    query = query.OrderByDescending(d => d.Price);
                }
                return await PaginateAsync(query!, queryParams);
            }
            if (queryParams.SortByNumberOfReviewsDescending != null)
            {
                if (queryParams.SortByNumberOfReviewsDescending == true)
                {
                    query = query.OrderByDescending(d => d.UserReviews.Count());
                }
                else
                {
                    query = query.OrderBy(d => d.UserReviews.Count());
                }
                return await PaginateAsync(query!, queryParams);
            }
            if (queryParams.SortByHighestReviewsDescending != null)
            {
                if (queryParams.SortByHighestReviewsDescending == true)
                {
                    query = query.OrderByDescending(d => d.UserReviews.Max());
                }
                else
                {
                    query = query.OrderBy(d => d.UserReviews.Max());
                }
                return await PaginateAsync(query!, queryParams);
            }

            return await PaginateAsync(query!, queryParams);
        }
    }
}
