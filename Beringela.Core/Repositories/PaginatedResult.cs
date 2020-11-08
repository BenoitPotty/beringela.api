using System.Collections.Generic;
using System.Linq;

namespace Beringela.Core.Repositories
{
    public class PaginatedResult<T>
    {
        public IEnumerable<T> Results { get; }
        public uint Page { get; }
        public uint PageSize { get; }
        public uint ResultStart { get; }
        public uint ResultEnd { get; } 
        public uint Count { get; }
        public uint TotalCount { get; }

        public PaginatedResult(IEnumerable<T> results, uint totalCount, PagingOptions pagingOptions = null)
        {
            //TODO Test

            TotalCount = totalCount;
            Results = results;
            Count = Results == null ? 0 : (uint)Results.Count();

            if (pagingOptions != null && pagingOptions.Paging)
            {
                Page = pagingOptions.Page;
                PageSize = pagingOptions.PageSize;
                ResultStart = Count == 0 ? 0 : ((Page - 1) * PageSize) + 1;
                ResultEnd = ResultStart + Count - 1;
            }
            else
            {
                Page = ResultStart = 1;
                PageSize = ResultEnd = Count;
            }
        }
    }
}
