namespace Beringela.Core.Repositories
{
    public class PagingOptions
    {
        public uint Page { get; set; }
        public uint PageSize { get; set; }
        public bool Paging => PageSize != 0 && Page != 0;
        public int Skip => (int) (PageSize * (Page - 1));

        public PagingOptions(uint page = 0, uint pageSize = 0)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}
