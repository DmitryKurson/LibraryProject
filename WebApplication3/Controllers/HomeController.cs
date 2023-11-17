using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcApp.Models;
using LibraryProject.Models;

namespace LibraryProject.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            db.books.Add(book);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id != null)
            {
                Book? book = await db.books.FirstOrDefaultAsync(p => p.Id == id);
                if (book != null)
                {
                    db.books.Remove(book);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(string? id)
        {
            if (id != null)
            {
                Book? book = await db.books.FirstOrDefaultAsync(p => p.Id == id);
                if (book != null) 
                    return View(book);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {
            db.books.Update(book);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index(string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = 3;

            IQueryable<Book> books = db.books;

            if (!string.IsNullOrEmpty(name))
            {
                books = books.Where(p => p.Name!.Contains(name));
            }

            books = sortOrder switch
            {
                SortState.NameAsc => books.OrderBy(s => s.Name),
                SortState.NameDesc => books.OrderByDescending(s => s.Name),
                SortState.IdAsc => books.OrderBy(s => s.Id),
                SortState.IdDesc => books.OrderByDescending(s => s.Id),
                SortState.AuthorAsc => books.OrderBy(s => s.Author),
                SortState.AuthorDesc => books.OrderByDescending(s => s.Author),
                _ => books.OrderBy(s => s.Name),
            };

            var count = await books.CountAsync();
            var items = await books.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel(
                items,
                new PageViewModel(count, page, pageSize),
                new FilterViewModel(name),
                new SortViewModel(sortOrder)
            );
            return View(viewModel);
        }
    }
}