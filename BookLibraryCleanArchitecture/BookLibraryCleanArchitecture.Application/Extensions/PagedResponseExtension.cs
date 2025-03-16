using BookLibraryCleanArchitecture.Application.Entities.Common;
using BookLibraryCleanArchitecture.Application.Entities.DataTransferObjects;
using BookLibraryCleanArchitecture.Domain.BookAggregate;
using System.Linq.Dynamic.Core;

namespace BookLibraryCleanArchitecture.Application.Extensions
{
    public static class PagedResponseExtension
    {
        public static async Task<PagedResponse<T>> CreatePagedReponseAsync<T>(this IQueryable<T> queryable, int pageIndex, int pageSize, 
            string sortColumn, string sortDirection, Dictionary<string,string> filters)
        {
            var totalCount = queryable.Count();
            if (pageIndex >= 0 && pageSize > 0)
            {
                queryable = queryable.Skip(pageIndex * pageSize)
                                .Take(pageSize);
            }

            if (filters != null)
            {
                string filterExpression;
                foreach (var filter in filters)
                {
                    if (filter.Value != null)
                    {
                        string columnName = $"{filter.Key[0].ToString().ToUpper()}{filter.Key.Substring(1)}";
                        string filterValue = filter.Value;

                        bool isStringColumn = typeof(Book).GetProperty(columnName)?.PropertyType == typeof(string);
                        if (!isStringColumn)
                        {
                            filterExpression = $"{columnName} == @0";
                        }
                        else
                        {
                            filterExpression = $"{columnName}.Contains(@0)";
                        }

                        // Apply the filter using Dynamic LINQ
                        queryable = queryable.Where(filterExpression, filterValue);
                    }
                }
            }

            IOrderedQueryable<T> orderedBooks = queryable as IOrderedQueryable<T>;
            if (!string.IsNullOrEmpty(sortColumn))
            {
                // Build the dynamic sorting expression
                var orderByExpression = $"{sortColumn} {sortDirection}";

                // Apply dynamic sorting
                orderedBooks = queryable.OrderBy(orderByExpression);

            }

            return new PagedResponse<T> { Rows = orderedBooks, TotalItems = totalCount };
        }
    }
}
