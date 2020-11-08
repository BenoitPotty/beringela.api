using System.Collections.Generic;
using System.Linq;

namespace Beringela.Core.Repositories
{
    public class PaginatedResult<T>
    {
        public IEnumerable<T> Results { get; private set; }
        public uint Page { get; private set; }
        public uint PageSize { get; private set; }
        public uint ResultStart => 0;
        public uint ResultEnd => 0;
        public uint Count => Results == null ? 0 : (uint)Results.Count();
        public uint TotalCount { get; private set; }

        public PaginatedResult<T> SetPage(uint page)
        {
            Page = page;
            return this;
        }

        public PaginatedResult<T> SetPageSize(uint pageSize)
        {
            PageSize = pageSize;
            return this;
        }

        public PaginatedResult<T> SetResult(IEnumerable<T> results)
        {
            Results = results;
            return this;
        }

        public PaginatedResult<T> SetTotalCount(uint totalCount)
        {
            TotalCount = totalCount;
            return this;
        }
    }
}
