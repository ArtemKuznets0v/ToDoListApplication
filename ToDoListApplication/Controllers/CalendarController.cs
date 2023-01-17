using Microsoft.AspNetCore.Mvc;
using ToDoListApplication.Data;

namespace ToDoListApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ApplicationDbContext _db;


        public CalendarController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Route("FindAllEvents")]
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
