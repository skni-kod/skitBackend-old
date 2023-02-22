namespace skitBackend.Wrappers
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int ItemsCount { get; set; }
        public int Offset
        {
            get
            {
                var tempPageIndex = PageNumber;

                if (tempPageIndex <= 0)
                    tempPageIndex = 1;

                return (tempPageIndex - 1) * PageSize;
            }
        }
        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling(ItemsCount / (double)PageSize);
            }
        }
    }
}
