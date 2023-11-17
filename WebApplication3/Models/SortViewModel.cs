namespace MvcApp.Models
{
    public class SortViewModel
    {
        public SortState IDSort  { get; }
        public SortState NameSort { get; } 
        public SortState AuthorSort { get; }
        public SortState Current { get; }     // текущее значение сортировки

        public SortViewModel(SortState sortOrder)
        {
            IDSort = sortOrder == SortState.IdAsc ? SortState.IdDesc : SortState.IdAsc;
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;           
            AuthorSort = sortOrder == SortState.AuthorAsc ? SortState.AuthorDesc : SortState.AuthorAsc;
            Current = sortOrder;
        }
    }
}