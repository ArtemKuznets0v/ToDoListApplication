using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoListApplication.Data;

namespace ToDoListApplication.Controllers
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }


        public void OnGet()
        {
        }

        public IActionResult OnGetFindAllEvents()
        {
            var events = _db.ToDoLists.Select(e => new
            {
                id = e.Id,
                title = e.NameTask,
                desc = e.Description,
                date = e.DateOfTask
            }).ToList();


            return new JsonResult(events);
        }
    }
}
