using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoListApplication.Data;
using ToDoListApplication.Interfaces;
using ToDoListApplication.Models;

namespace ToDoListApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IHomeControllerService service;


        public HomeController(ApplicationDbContext db, IHomeControllerService service)
        {
            _db = db;
            this.service = service;
        }

        //GET
        public IActionResult Index(string? searchDay, string? searchMonth, string? searchYear, int pg = 1)
        {

            const int pageSize = 10;
            if (pg < 1)
                pg = 1;

            return View(new Pageres<ToDoListModel>
            {
                Items = service.SearchPaged(searchDay, searchMonth, searchYear, pageSize, pg),
                SearchDay = searchDay,
                SearchMonth = searchMonth,
                SearchYear = searchYear

            });

        }

       // public IActionResult Index() => View(service.GetAllTasks());
       
        //GET
        public IActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ToDoListModel task)
        {

            if (ModelState.IsValid)
            {
                service.CreateNewTask(task);
                return RedirectToAction("Index");
            }
            return View(task);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var taskFromDb = _db.ToDoLists.Find(id);
            if (taskFromDb == null)
            {
                return NotFound();
            }
            return View(taskFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ToDoListModel task)
        {

            if (ModelState.IsValid)
            {
                service.UpdateTask(task);
                TempData["success"] = "Task updated successfully";
                return RedirectToAction("Index");
            }
            return View(task);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var taskFromDb = _db.ToDoLists.Find(id);
            if (taskFromDb == null)
            {
                return NotFound();
            }
            return View(taskFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.ToDoLists.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            service.DeleteTask(obj);
            TempData["success"] = "Task deleted successfully";
            return RedirectToAction("Index");

            return View(obj);
        }

    }
}