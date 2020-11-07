using System.Collections.Generic;
using System.Linq;

namespace SortingPagination.Models
{
    public class ListResult<T>
    {
        public IEnumerable<T> Content { get; }

        public int TotalCount { get; }

        public bool HasNextPage { get; }

        public ListResult(IEnumerable<T> content)
        {
            Content = content;
            TotalCount = content?.Count() ?? 0;
            HasNextPage = false;
        }

        public ListResult(IEnumerable<T> content, int totalCount, bool hasNextPage = false)
        {
            Content = content;
            TotalCount = totalCount;
            HasNextPage = hasNextPage;
        }
    }
}
