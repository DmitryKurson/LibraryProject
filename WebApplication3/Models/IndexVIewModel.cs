using LibraryProject.Models;

namespace MvcApp.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Book> books { get; }
        public PageViewModel PageViewModel { get; }
        public FilterViewModel FilterViewModel { get; }
        public SortViewModel SortViewModel { get; }
        public IndexViewModel(IEnumerable<Book> users, PageViewModel pageViewModel,
            FilterViewModel filterViewModel, SortViewModel sortViewModel)
        {
            books = users;
            PageViewModel = pageViewModel;
            FilterViewModel = filterViewModel;
            SortViewModel = sortViewModel;
        }
    }
}