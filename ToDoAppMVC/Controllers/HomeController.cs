using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using ToDoAppMVC.Entities;
using ToDoAppMVC.Models;
using ToDoAppMVC.Services;

namespace ToDoAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITaskRepository _taskRepository;
        private List<TaskEntity> Tasks;


        public HomeController(ILogger<HomeController> logger, ITaskRepository taskRepository)
        {
            _logger = logger;
            _taskRepository = taskRepository;
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
        public IActionResult Add(CreateTaskViewModel task)
        {
            if (!ModelState.IsValid)
            {
                return View(task);
            }
            _taskRepository.Add(task);
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
                    Title = "Estudiar React"
                },
                new TaskEntity()
                {
                    Id = 2,
                    Title = "Estudiar SignalR"
                },
                new TaskEntity()
                {
                    Id = 3,
                    Title = "Estudiar Angular"
                },
                new TaskEntity()
                {
                    Id = 4,
                    Title = "Estudiar MVC"
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
