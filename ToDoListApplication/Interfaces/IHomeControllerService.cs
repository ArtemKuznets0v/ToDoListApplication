using ToDoListApplication.Models;

namespace ToDoListApplication.Interfaces
{
    public interface IHomeControllerService
    {
        IEnumerable<ToDoListModel> GetAllTasks();
        void CreateNewTask(ToDoListModel task);
        void DeleteTask(ToDoListModel task);
        void UpdateTask(ToDoListModel task);
        Pager<ToDoListModel> SearchPaged(string? searchDay, string? searchMonth, string? searchYear, int pageSize, int currentPage);
    }
}
