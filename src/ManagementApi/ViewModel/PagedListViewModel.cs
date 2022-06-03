using System.ComponentModel;

namespace ManagementApi.ViewModel
{
    [DisplayName("PagedList")]
    public class PagedListViewModel<T> where T : class
    {
        public PagedListViewModel(int? page, int? pageSize, int? itemsCount, IList<T> result)
        {
            Page = page;
            PageSize = pageSize;
            ItemsCount = itemsCount;
            Result = result;
        }

        public int? Page { get; private set; }
        public int? PageCount =>
            ItemsCount != null && PageSize != null
                ? (int)Math.Ceiling((int)ItemsCount / (double)PageSize)
                : null;

        public int? PageSize { get; private set; }
        public int? ItemsCount { get; private set; }
        public IList<T> Result { get; private set; }
    }
}
