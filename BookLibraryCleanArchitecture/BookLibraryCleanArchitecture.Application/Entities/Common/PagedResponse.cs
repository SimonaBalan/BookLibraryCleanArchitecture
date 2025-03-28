﻿namespace BookLibraryCleanArchitecture.Application.Entities.Common
{
    public class PagedResponse<T>
    {
        public IOrderedQueryable<T> Rows { get; set; }

        public int TotalItems { get; set; }
    }
}
