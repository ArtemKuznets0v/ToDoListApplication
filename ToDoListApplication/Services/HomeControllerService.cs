using Azure;
using System.Linq;
using ToDoListApplication.Data;
using ToDoListApplication.Interfaces;
using ToDoListApplication.Models;

namespace ToDoListApplication.Services
{
    public class HomeControllerService : IHomeControllerService
    {
        private readonly ApplicationDbContext _db;

        public HomeControllerService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<ToDoListModel> GetAllTasks() => _db.ToDoLists.ToList().OrderBy(x=>x.DateOfTask);

        public void CreateNewTask(ToDoListModel task)
        {
            _db.ToDoLists.Add(task);
            _db.SaveChanges();
        }

        public void DeleteTask(ToDoListModel task)
        {
            _db.ToDoLists.Remove(task);
            _db.SaveChanges();
        }

        public void UpdateTask(ToDoListModel task)
        {
            _db.ToDoLists.Update(task);
            _db.SaveChanges();
        }

        public Pager<ToDoListModel> SearchPaged(string? searchDay, string? searchMonth, string? searchYear, int pageSize, int currentPage)
        {
            var taskDate = _db.ToDoLists.AsQueryable();
            

            if (!String.IsNullOrEmpty(searchDay))
            {
                
                taskDate = taskDate.Where( 
                    s => s.DateOfTask.Day.ToString().StartsWith(searchDay)
                    );
                
            }
            if (!String.IsNullOrEmpty(searchMonth))
            {

                taskDate = taskDate.Where(
                    s => s.DateOfTask.Month.ToString().StartsWith(searchMonth)
                    );

            }
            if (!String.IsNullOrEmpty(searchYear))
            {

                taskDate = taskDate.Where(
                    s => s.DateOfTask.Year.ToString().StartsWith(searchYear)
                    );

            }
            int recsCount = taskDate.Count();

                int recSkip = (currentPage - 1) * pageSize;

                var data = taskDate.Skip(recSkip).Take(pageSize).ToList();

                return new Pager<ToDoListModel> { CurrentPage = currentPage, PageCount = (int)Math.Ceiling(recsCount / (double)pageSize), Items = data, PageSize = pageSize, TotalCount = recsCount };
            
        }
        // public IEnumerable<ToDoListModel> GetTaskByDate() => _db.ToDoLists.Where(x => x.DateOfTask.Equals(x.DateOfTask.Day)).ToList();
    }
}
