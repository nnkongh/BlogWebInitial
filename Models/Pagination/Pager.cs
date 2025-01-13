using Microsoft.EntityFrameworkCore;

namespace BlogWeb.Models.Pagination
{
    public class Pager<T>
    {
        public IEnumerable<T> Items { get; set; } = [];
        public int TotalItem { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; private set; }

        public Pager(IEnumerable<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            Items = items;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize); // count = 99, pagesize = 10.0 => 99 / 10 = 9.9 => 10 trang
            //=> Math.Celling làm tròn số thực thành số nguyên gần nhất
        }
        public bool HasPreviousPage => (PageIndex > 1);
        public bool HasNextPage => (PageIndex < TotalPages);
        public int FirstItemIndex => (PageIndex - 1) * PageSize + 1;
        public int LastItemIndex => Math.Min(PageIndex * PageSize, TotalItem);
        public static async Task<Pager<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync(); // total number of items in data source
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new Pager<T>(items, count, pageIndex, pageSize);
        }
    }
}

