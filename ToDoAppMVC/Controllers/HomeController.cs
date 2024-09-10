using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoAppMVC.Entities;
using ToDoAppMVC.Models;

namespace ToDoAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<TaskEntity> Tasks;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            Tasks = GetTasks();
        }

        public IActionResult Index()
        {
            return View("Index", Tasks);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string taskName)
        {
            var newTask = new TaskEntity()
            {
                Id = 5,
                Name = taskName
            };
            Tasks.Add(newTask);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var tasks = GetTasks();
            tasks = tasks.Where(t => t.Id != id).ToList();
            return View(tasks);
        }

        private List<TaskEntity> GetTasks()
        {
            var tasks = new List<TaskEntity>() {
                new TaskEntity()
                {
                    Id = 1,
                    Name = "Estudiar React"
                },
                new TaskEntity()
                {
                    Id = 2,
                    Name = "Estudiar SignalR"
                },
                new TaskEntity()
                {
                    Id = 3,
                    Name = "Estudiar Angular"
                },
                new TaskEntity()
                {
                    Id = 4,
                    Name = "Estudiar MVC"
                }
            };
            return tasks;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
